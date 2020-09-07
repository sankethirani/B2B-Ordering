using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCManukauTech.Models.DB;
using Newtonsoft.Json;

namespace MVCManukauTech.Controllers
{
    public class CatalogController : Controller
    {
        private readonly F191_NSS_ProjectContext _context;

        public CatalogController(F191_NSS_ProjectContext context)
        {
            _context = context;
        }

        // GET: Catalog
        // GET: Catalog?searchString=
        // NV Edit view result to show fruits only
        public async Task<IActionResult> Index(string sortOrder ,string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            string sql = "SELECT DISTINCT * FROM Product WHERE ProductName LIKE @p0 AND CategoryId=1";
            string _searchString = "%" + searchString + "%";

            var products = _context.Product.FromSql(sql, _searchString);

            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(p => p.ProductName);
                    break;
                case "Price":
                    products = products.OrderBy(p => p.UnitPrice);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.UnitPrice);
                    break;
                default:
                    products = products.OrderBy(p => p.ProductName);
                    break;
            }

            return View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, 6));
        }

        public string IndexAJAX(string searchString)
        {
            string sql = "SELECT DISTINCT * FROM Product WHERE ProductName LIKE @p0 AND CategoryId=1";
            string _searchString = "%" + searchString + "%";
            List<Product> products = _context.Product.FromSql(sql, _searchString).ToList();

            List<string> searchList = new List<string>();
            foreach (Product item in products)
            {
                if (item.ProductName.ToLower().Contains(searchString.ToLower())
                    && !(searchList.Contains(item.ProductName)))
                {
                    searchList.Add(item.ProductName);
                }
            }
            string json = JsonConvert.SerializeObject(searchList);
            return json;
        }


        // GET: Catalog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                //.Include(p => p.Category)
                //.Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        
        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
