using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopMarket.Data;
using ShopMarket.Models;

namespace ShopMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MarketShopContext _context;
        private static Cart _cart = new Cart();
        public HomeController(ILogger<HomeController> logger,MarketShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var Products = _context.products.ToList();
            return View(Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var product = _context.products.Find(id);
            
            if (product == null)
            {
                return NotFound();
            }

            var Categories = _context.products.Where(p => p.id == id).SelectMany(c => c.categorytoProducts)
                .Select(ca => ca.CategoryId).ToList();
            //استفاده از ویو مدل
            var vm = new DetailsViewModel()
            {
                product = product,
                Categories = Categories
            };
            return View(vm);
        }
        //اضافه کردن به سبد خرید
        public IActionResult AddtoCart(int ItemId)
        {
            var product = _context.products.Include(p=>p.items).SingleOrDefault(p => p.id == ItemId);
            if (product != null)
            {
                var cartitem = new CartItem()
                {
                    item = product.items,
                    Quantity = 1
                };
                //اضافه کردن Quantity
                _cart.AddItem(cartitem);
            }
            return RedirectToAction("ShowCart");
        }
        //نمایش سبد خرید
        public IActionResult ShowCart()
        {
            //ویومدل کارت
            var CartVM = new CartViewModel()
            {
                CartItems = _cart.cartItems,
                //بدست آوردن مجموع قیمت مقادیر موجود در سبد خرید
                OrderTotal = _cart.cartItems.Sum(c => c.getTotalPrice())
            };
            return View(CartVM);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
