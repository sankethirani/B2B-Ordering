using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCManukauTech.Areas.Identity.Data;
using MVCManukauTech.Models;
using MVCManukauTech.Models.DB;

namespace MVCManukauTech.Controllers
{
    public class HomeController : Controller
    {
        private readonly F191_NSS_ProjectContext _context;
        private readonly UserManager<MVCManukauTechUser> _userManager;

        public HomeController(F191_NSS_ProjectContext context, UserManager<MVCManukauTechUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var id = _userManager.GetUserId(User);
            if(id != null )
            {
                string sql = "SELECT * FROM AspNetUsers WHERE Id = @p0";
                var currentUser = _context.AspNetUsers.FromSql(sql, id).SingleOrDefault();
                if(currentUser.MembershipType != "none" && currentUser.ExpiryDate < System.DateTime.Now) { return Redirect("~/Membership/MembershipExpired"); }
            }

            return View();
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
