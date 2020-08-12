using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Data;

namespace ShopMarket.Controllers
{
    public class ProductController : Controller
    {
        private MarketShopContext _context;
        public ProductController(MarketShopContext context)
        {
            context = _context;
        }
        [Route("Group/{id}/{name}")]
        public IActionResult GetProductgroupId(int Id)
        {
            var product = _context.categorytoProducts.Where(c => c.CategoryId == Id)
                .Include(c => c.product)
                .Select(c => c.product)
                .ToList();
            return View();
        }
    }
}
