using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCManukauTech.Areas.Identity.Data;
using MVCManukauTech.Models.DB;
using MVCManukauTech.ViewModels;

namespace MVCManukauTech.Controllers
{
    public class CheckoutController : Controller
    {
        
        private readonly F191_NSS_ProjectContext _context;
        private readonly UserManager<MVCManukauTechUser> _userManager;
        private AspNetUsers currentUser;



        public CheckoutController(F191_NSS_ProjectContext context, UserManager<MVCManukauTechUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Index()
        {
            //Calculate the grand total for display and processing
            int orderId = Convert.ToInt32(HttpContext.Session.GetInt32("OrderId"));

            //Use the orderId to get the GrandTotal out of the database
            string SQLGetNetTotal = "SELECT SUM(Quantity * UnitPrice) AS GrossTotal FROM OrderDetail WHERE OrderId = @p0";

            try
            {
                var grossTotals = _context.GrandTotalViewModel.FromSql(SQLGetNetTotal, orderId).ToList();
                decimal grossTotal = grossTotals[0].GrossTotal;
                var checkout = new CheckoutViewModel();
                checkout.GrossTotal = grossTotal;
                
                
                if (isLoggedIn() == true)
                {                    
                    string updateOrder = "UPDATE [Order] SET CustomerId = @p0";
                    //string sql = "SELECT * FROM AspNetUsers WHERE Id = @p0";
                    //var currentUser = _context.AspNetUsers.FromSql(sql, id).SingleOrDefault();
                    if (currentUser.MembershipType != "none" && currentUser.ExpiryDate < System.DateTime.Today) { return Redirect("~/Membership/MembershipExpired"); }
                    else
                    {
                        checkout.StreetAddress = currentUser.StreetAddress;
                        checkout.ShipName = currentUser.Name;
                        checkout.City = currentUser.City;
                        checkout.PostalCode = currentUser.PostalCode;
                        if (currentUser.MembershipType.ToLower() == "gold")
                        {
                            //15% discount                        
                            checkout.Discount = 0.15M * grossTotal;
                        }
                        else if (currentUser.MembershipType.ToLower() == "silver")
                        {
                            //10% discount
                            checkout.Discount = 0.1M * grossTotal;
                        }
                        else if (currentUser.MembershipType.ToLower() == "bronze")
                        {
                            //7% discount
                            checkout.Discount = 0.07M * grossTotal;
                        }

                        _context.Database.ExecuteSqlCommand(updateOrder, currentUser.Id);
                        _context.SaveChanges();
                    }
                }

                decimal grandTotal = checkout.GrossTotal - checkout.Discount;
                
                HttpContext.Session.SetString("GrandTotal", grandTotal.ToString());
                ViewData["GrandTotal"] = Math.Round(grandTotal, 2).ToString();
                return View(checkout);
            }

            catch
            {
                return Redirect("~/Catalog");
            }

        }
        

        public string PaypalResult(string paypalID)
        {
            int orderId = Convert.ToInt32(HttpContext.Session.GetInt32("OrderId"));

            string message = "";

            if (paypalID != null && paypalID != "")
            {
                message = "Done";
                string SQL = @"UPDATE [Order] SET TransactionId = @p0 WHERE OrderId = @p1";

                _context.Database.ExecuteSqlCommand(SQL, paypalID, orderId);
            }
            else
            {
                message = "Error";
            }
            
            return message;
        }
        
        public void CheckoutUpdateDatabase(string shipName, string shipAddress, decimal grossTotal, decimal discount, decimal netTotal)
        {

            int orderId = Convert.ToInt32(HttpContext.Session.GetInt32("OrderId"));
            updateMembership();
            updateProductQuantities();

            //update database with order details after checkout
            var order = _context.Order.Where(o => o.OrderId == orderId).FirstOrDefault();
                order.OrderDate = DateTime.Now;
                order.ShipName = shipName;
                order.ShipAddress = shipAddress;
                order.GrossTotal = grossTotal;
                order.Discount = discount;
                order.NetTotal = netTotal;
                order.OrderStatusId = 2;
                _context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges(); 
            //reset order id
            HttpContext.Session.SetInt32("OrderId", 0);
        }

        //NV change quantity of products when buyer buys a product
        private void updateProductQuantities()
        {
            int orderId = Convert.ToInt32(HttpContext.Session.GetInt32("OrderId"));
            var cartItems = _context.OrderDetail.Where(o => o.OrderId == orderId).ToList();
            foreach (var item in cartItems)
            {
                var pId = item.ProductId;
                var product = _context.Product.Where(p => p.ProductId == pId).SingleOrDefault();
                product.QuantityInStock -= item.Quantity;
                _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        //SKH function for updating user membership if membership is bought
        private void updateMembership()
        {
            var boolean = isLoggedIn();
            
            int orderId = Convert.ToInt32(HttpContext.Session.GetInt32("OrderId"));
            var cartItems = _context.OrderDetail.Where(o => o.OrderId == orderId).ToList();
            foreach(var item in cartItems)
            {
                if (item.ProductId == 100)
                {
                    currentUser.MembershipType = "gold";
                    currentUser.ExpiryDate = DateTime.Now.AddMinutes(2);
                    break;
                }
                else if (item.ProductId == 101)
                {
                    currentUser.MembershipType = "silver";
                    currentUser.ExpiryDate = DateTime.Now.AddYears(1);
                    break;
                }
                else if (item.ProductId == 102)
                {
                    currentUser.MembershipType = "bronze";
                    currentUser.ExpiryDate = DateTime.Now.AddMinutes(2);
                    break;
                }

            }
        }

        private bool isLoggedIn()
        {
            var loggedIn = false;
            var id = _userManager.GetUserId(User);
            if(id != null)
            {
                currentUser = _context.AspNetUsers.Where(u => u.Id == id).FirstOrDefault();
                loggedIn = true;
            }
            return loggedIn;
        }

        public IActionResult CheckoutResult()
        {
            return View();
        }
    }
}