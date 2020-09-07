using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCManukauTech.Models.DB;
using MVCManukauTech.ViewModels;

namespace MVCManukauTech.Controllers
{
    public class OrderDetailsController : Controller
    {
        
        private readonly F191_NSS_ProjectContext _context;

        public OrderDetailsController(F191_NSS_ProjectContext context)
        {
            _context = context;
        }
        
        // GET: OrderDetails/ShoppingCart?ProductId=1MOR4ME
        // or to simply view the cart
        // GET: OrderDetails/ShoppingCart
        public IActionResult ShoppingCart()
        {
            string SQLGetOrder = "";
            string SQLStartOrder = "";
            string SQLCart = "";
            string SQLBuy = "";
            string SQLUnitCostLookup = "";
            int rowsChanged = 0;
            // NV Changed to int
            int ProductId = Convert.ToInt32(Request.Query["ProductId"]);

            //SKH to check if there is already a membership product added to the cart
            if(checkCartForMembershipProduct(ProductId))
            {
                return Redirect("/Membership/MembershipAlreadyInCart");
            }

            else
            {
                //Have we created an order for this user yet?
            //If not then create a placeholder for a mostly empty order
            //Note that any Order in progress has an OrderStatusId of 0 or 1
            //We are not interested in Orders with higher status because they have already gone through checkout
            //2015-08-07 JPC Security improvement implementation of @p0
            //2019-03-19 JPC Change of table name from Orders to Order causes keyword clash 
            //  and therefore need to wrap Order in square brackets!
            SQLGetOrder = "SELECT * FROM [Order] WHERE SessionId = @p0 AND OrderStatusId <= 1;";

            //140825 JPC.  We may need 2 attempts at reading the order out of the database.
            //  Managing this as a for..loop with 2 loops.  If successful first time then break out.
            //  (Other opinion Rosemarie T - "this is a bit dodgy!")
            //150807 JPC Security improvement implementation of @p0
            var orders = _context.Order.FromSql(SQLGetOrder, HttpContext.Session.Id).ToList();
            for (int i = 0; i <= 1; i++)
            {
                //Do we have an order?
                if (orders.Count == 1)
                {
                    //we have an order, we can continue to the next step
                    break;
                }
                else if (i == 1)
                {
                    //failed on the second attempt
                    throw new Exception("ERROR with database table 'Order'.  This session fails to write a new order.");
                }
                else if (orders.Count > 1)
                {
                    //This would be a major error. In theory impossible but we need to be ready for any outcome
                    throw new Exception("ERROR with database table 'Order'.  This session is running more than one shopping cart.");
                }
                else
                {
                    //else we get an order started
                    //150807 JPC Security improvement implementation of @p0
                    SQLStartOrder = "INSERT INTO [Order](SessionId, OrderStatusId) VALUES(@p0, 0);";
                    rowsChanged = _context.Database.ExecuteSqlCommand(SQLStartOrder, HttpContext.Session.Id);
                    // a good result would be one row changed
                    if (rowsChanged != 1)
                    {
                        //Error handling code to go in here.  Poss return a view with error messages.
                        //Code from our old webforms version is -- 
                        throw new Exception("ERROR with database table 'Order'.");
                    }
                    //ready to try reading that order again
                    //150807 JPC Security improvement implementation of @p0, parameter Session.SessionID
                    orders = _context.Order.FromSql(SQLGetOrder, HttpContext.Session.Id).ToList();
                    //go round and test orders again
                }
            }

            //What is the OrderId
            int orderId = orders[0].OrderId;
            
            //150807 JPC Security improvement implementation of @p0
            //20180313 JPC temp drop parameter because of problems
            SQLCart = @"SELECT OrderDetail.OrderId AS OrderId, OrderDetail.LineNumber As LineNumber, OrderDetail.ProductId As ProductId,
                Product.ProductName As ProductName, Product.ImageFileName As ImageFileName,
                OrderDetail.Quantity As Quantity, OrderDetail.UnitPrice As UnitCost
                FROM OrderDetail INNER JOIN Product ON Product.ProductId = OrderDetail.ProductId
                WHERE OrderDetail.OrderId = @p0 ORDER BY OrderDetail.LineNumber;";
            // Note that this is an "view" query across 2 tables 
            // so we need to create a new VIEW MODEL class "OrderDetailsQueryForCart" to match up
            // See this under folder "ViewModels"
            //150807 JPC Security improvement implementation of @p0, parameter orderId
            var cart = _context.OrderDetailsQueryForCartViewModel.FromSql(SQLCart, orderId).ToList();

            //140903 JPC
            //What to do about a product for the case where the user clicked add to cart ..
            //IF the product is already in the cart THEN raise the quantity by one ELSE add it in

            int lineNumber = 0;
            int? quantity = 0;

            //140903 JPC cover case of user is only looking at the cart without adding any changes
            if (ProductId == 0)
            {
                //use lineNumber = -1 as a flag to skip the data writing in the following "if" block
                lineNumber = -1;
            }
            else
            {
                foreach (var item in cart)
                {
                    //NV changed here for int ProductID
                    if (item.ProductId == ProductId)
                    {
                        lineNumber = item.LineNumber;
                        quantity = item.Quantity;
                        break;
                    }
                }
            } //end if

            rowsChanged = 0;
            if (lineNumber > 0)
            {
                quantity += 1;
                //150807 JPC Security improvement implementation of @p0, @p1, @p2 - (was {0}, {1}, {2})
                SQLBuy = "UPDATE OrderDetail SET Quantity = @p0 WHERE OrderId = @p1 AND LineNumber = @p2 ";
                rowsChanged = _context.Database.ExecuteSqlCommand(SQLBuy, quantity, orderId, lineNumber);
            }
            else if (lineNumber == 0)
            {
                //writing a new line.  we need to know the unitcost
                //in real life work this could grow into a major method in a separate class involving special member discounts etc
                //here there is a choice between sending it in the querystring, or doing a new database lookup 
                //the querystring is easier but I am concerned about users being able to interfere with querystrings so I will go with the database

                //Safe bet is to stick to the SELECT * approach to match the existing generated classes.  
                //Can also call this the "go with the flow" method
                //150807 JPC Security improvement implementation of @p0
                SQLUnitCostLookup = "SELECT * FROM Product WHERE ProductId = @p0";
                var products = _context.Product.FromSql(SQLUnitCostLookup, ProductId).ToList();
                decimal unitCost = Convert.ToDecimal(products[0].UnitPrice);

                lineNumber = cart.Count + 1;
                //150807 JPC Security improvement implementation of @p0 etc
                SQLBuy = "INSERT INTO OrderDetail VALUES(@p0, @p1, @p2, @p3, @p4)";
                rowsChanged = _context.Database.ExecuteSqlCommand(SQLBuy, orderId, lineNumber, ProductId, 1, unitCost);
            }

            //If User has selected a product to add then Query is UPDATE or INSERT but they both run like this
            if (SQLBuy != "")
            {
                if (rowsChanged != 1)
                {
                    //Error handling code to go in here.  Poss return a view with error messages.
                    //Code from our old webforms version is -- 
                    throw new Exception("ERROR with database table 'Order'.");
                }

                //If we have changed the cart in the database, then we need to reload it here
                //140903 JPC note the syntax for working with a "View Model"
                //150807 JPC Security improvement implementation of @p0, parameter orderId
                cart = _context.OrderDetailsQueryForCartViewModel.FromSql(SQLCart, orderId).ToList();
            }

            //Give that Session object some work to do to wake it up and get it functional
            HttpContext.Session.SetInt32("OrderId", orderId);
            //20180312 JPC use ViewBag to get the orderId to the cart for display
            ViewBag.OrderId = orderId;
            return View(cart);
            }

            

        }
        

        [HttpPost]
        public string ShoppingCartUpdate(string Quantity, string LineNumber)
        {
            string SQLUpdateOrderDetails = "";
            int rowsChanged = 0;

            //140903 JPC check that Quantity and LineNumber are numeric. Non-numeric or decimal could indicate hacker mischief-making
            //20180312 JPC IsNumeric method is coded at the bottom of this class
            if (!IsNumeric(Quantity) || !IsNumeric(LineNumber)
                || Convert.ToInt32(Quantity) != Convert.ToDouble(Quantity)
                || Convert.ToInt32(LineNumber) != Convert.ToDouble(LineNumber))
            {
                //TODO Code to log this event and send alert email to admin
                return "ERROR";
            }
            int orderId = Convert.ToInt32(HttpContext.Session.GetInt32("OrderId"));
            //150807 JPC Security improvement implementation of @p0 etc
            SQLUpdateOrderDetails = "UPDATE OrderDetail SET Quantity = @p0 WHERE OrderId = @p1 AND LineNumber = @p2";
            rowsChanged = _context.Database.ExecuteSqlCommand(SQLUpdateOrderDetails, Quantity, orderId, LineNumber);
            if (rowsChanged == 1)
            {
                //expected good result
                return "SUCCESS";
            }
            else if (rowsChanged == 0)
            {
                //nothing happened, a bit sad but there is no change so simple feedback is needed
                return "ERROR";
            }
            else
            {
                //more than 1 rows changed is in theory impossible.
                //the only possibility I can think of is some kind of hacking injection attack where % signs
                //get into the mix and give a wider scope to what the WHERE statement finds.
                //if it does happen then we have a major problem on our hands and we need 
                //to cancel this shopping cart immediately 
                //needs SQL DELETE for the cart
                return "ERROR HIGH SEVERITY"; //placeholder only, 
            }

        }

        
        public void DeleteFromCart(int LineNumber)
        {            
            int orderId = Convert.ToInt32(HttpContext.Session.GetInt32("OrderId"));
            string SQLDeleteOrderItem = "DELETE FROM OrderDetail WHERE OrderDetail.OrderId = @p0 AND OrderDetail.LineNumber = @p1";            
            _context.Database.ExecuteSqlCommand(SQLDeleteOrderItem, orderId, LineNumber);
            _context.SaveChanges();
        }


        //get /OrderDetails/checkCartForMembershipProduct?productid=100
        public bool checkCartForMembershipProduct(int productId)
        {
            int orderId = Convert.ToInt32(HttpContext.Session.GetInt32("OrderId"));
            var result = false;
            if (productId != 0)
            {
                var product = _context.Product.Where(p => p.ProductId == productId).FirstOrDefault();
                if (product.CategoryId == 2)
                {                    
                    var cartItems = _context.OrderDetail.Where(o => o.OrderId == orderId).ToList();
                    foreach (var item in cartItems)
                    {
                        if(item.ProductId == 100 || item.ProductId == 101 || item.ProductId == 102)
                        {
                            result = true;
                        }
                    }
                }
            }
            
            return result;
        }

        private bool IsNumeric(string value)
        {
            bool b = true;
            int result = 0;
            int.TryParse(value, out result);
            if (result == 0) b = false;
            return b;
        }

        
    }
}