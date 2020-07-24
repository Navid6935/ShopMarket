using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMarket.Models
{
    public class Cart
    {
        public Cart()
        {
            cartItems = new List<CartItem>();
        }
        public int OrderId { get; set; }
        public List<CartItem> cartItems { get; set; }

        public void AddItem(CartItem item)
        {
            //اگر آیتم وجود داشت تعداد آن را افزایش بده
            if (cartItems.Exists(i=>i.item.ItemId == item.Id))
            {
                cartItems.Find(i => i.item.ItemId == item.item.ItemId)
                    .Quantity += 1;
            }
            //اگر وجود نداشت اضافه کن
            else
            {
                cartItems.Add(item);
            }
        }
        public void RemoveItem(int itemId)
        {
            var item = cartItems.SingleOrDefault(c=>c.item.ItemId == itemId);
            //اگر آیتم خالی نبود و تعداد کوچکترمساوی یک بود
            if (item?.Quantity <= 1)
            {
                cartItems.Remove(item);
            }
            //اگر آیتم نال نبود
            else if(item != null)
            {
                item.Quantity -= 1;
            }

        }
    }
}
