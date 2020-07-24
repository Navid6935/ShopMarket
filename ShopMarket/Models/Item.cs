using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMarket.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        #region Relation
        //Navigation preperty
        public Product product { get; set; }
        #endregion
    }
}
