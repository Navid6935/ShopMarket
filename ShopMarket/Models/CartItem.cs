using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMarket.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Item item { get; set; }
        public int Quantity { get; set; }
        //بدست آوردن جمع کل قیمت ها
        public decimal getTotalPrice()
        {
            return item.Price * Quantity; 

        }
    }
}
