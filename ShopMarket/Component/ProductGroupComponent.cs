using Microsoft.AspNetCore.Mvc;
using ShopMarket.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMarket.Component
{
    public class ProductGroupComponent : ViewComponent
    {
        MarketShopContext _context;
        public ProductGroupComponent(MarketShopContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Component/ProductGroupComponent.cshtml", _context.cateories);
        }
    }
}
