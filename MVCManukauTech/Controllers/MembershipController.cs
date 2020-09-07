using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCManukauTech.Models.DB;
using Microsoft.AspNetCore.Identity;
using MVCManukauTech.Areas.Identity.Data;

namespace MVCManukauTech.Controllers
{

    public class MembershipController : Controller
    {
        private readonly F191_NSS_ProjectContext _context;
        private readonly UserManager<MVCManukauTechUser> _userManager;

        public MembershipController(F191_NSS_ProjectContext context, UserManager<MVCManukauTechUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            string sql = "SELECT ProductId, ProductName, UnitPrice, Description, ImageFileName " +
                         "FROM Product WHERE CategoryId = 2";
            var membership = _context.MembershipViewModel.FromSql(sql).ToList();
            return View(membership);
        }

        //display page to let the user know that his/her membership has expired
        public IActionResult MembershipExpired()
        {
            return View();
        }

        public string RenewMembership()
        {
            var id = _userManager.GetUserId(User);
            int productId = 0;
            if (id != null)
            {
                string sql = "SELECT * FROM AspNetUsers WHERE Id = @p0";
                var currentUser = _context.AspNetUsers.FromSql(sql, id).SingleOrDefault();
                var membershipType = currentUser.MembershipType;
                if(membershipType == "gold") { productId = 100; }
                else if (membershipType == "silver") { productId = 101; }
                else { productId = 102; }
            }
            return productId.ToString();
            //return Redirect("~/OrderDetails/ShoppingCart?ProductId=" + productId);
        }

        public void CancelMembership()
        {
            var id = _userManager.GetUserId(User);
            string SQL = "UPDATE AspNetUsers SET MembershipType = 'none' WHERE Id = @p0";
            _context.Database.ExecuteSqlCommand(SQL, id);
            _context.SaveChanges();
        }

        public IActionResult MembershipAlreadyInCart()
        {
            return View();
        }
        

    }
}