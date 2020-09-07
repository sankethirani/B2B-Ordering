using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCManukauTech.Models.DB;

namespace MVCManukauTech.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AspNetUserRolesController : Controller
    {
        private readonly F191_NSS_ProjectContext _context;

        public AspNetUserRolesController(F191_NSS_ProjectContext context)
        {
            _context = context;
        }

        // GET: AspNetUserRoles
        public async Task<IActionResult> Index()
        {
            var f191_NSS_ProjectContext = _context.AspNetUserRoles.Include(a => a.Role).Include(a => a.User);
            return View(await f191_NSS_ProjectContext.ToListAsync());
        }

        // GET: AspNetUserRoles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUserRoles = await _context.AspNetUserRoles
                .Include(a => a.Role)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (aspNetUserRoles == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.AspNetRoles, "Id", "Id", aspNetUserRoles.RoleId);
            return View(aspNetUserRoles);
        }

        // https://localhost:44308/AspNetUserRoles/EditAJAX?userId=3b78785a-2ffa-4a1c-b9af-a36c27737183&roleName=Customer
        public string  EditAJAX(string userId, string roleName)
        {
            
           
            string xString = "%" + userId + "%";
            string roleId ="";

            try
            {
                if (roleName == "Admin")
                {
                    roleId = "1";
                }
                else if (roleName == "Customer")
                {
                    roleId = "2";
                }

                string postsql = "UPDATE[AspNetUserRoles] SET RoleId = @p0 WhERE UserId = @p1";

                _context.Database.ExecuteSqlCommand(postsql, roleId, userId);
                _context.SaveChanges();

                return ("Success");
                
            }
            catch 
            {
                return ("Fail");
            }

        }

        private bool AspNetUserRolesExists(string id)
        {
            return _context.AspNetUserRoles.Any(e => e.UserId == id);
        }
    }
}
