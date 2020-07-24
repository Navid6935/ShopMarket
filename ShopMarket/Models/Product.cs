using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMarket.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }      
        public string Name { get; set; }
        public string Description { get; set; }
        //Foregin Key
        public int ItemId { get; set; }
        #region MyRegion
        //Navogation Property
        //رابطه یک به چند
        public ICollection<CategorytoProduct> categorytoProducts { get; set; }
        //رابطه یک به چند با جدول سبد خرید
        public Item items { get; set; }

        #endregion
    }
}
