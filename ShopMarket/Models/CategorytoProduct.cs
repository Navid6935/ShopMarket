using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMarket.Models
{
    public class CategorytoProduct
    {

        public int productId { get; set; }
        public int CategoryId { get; set; }
        #region Relation
        //Navigation Property
        //رابطه یک به یک
        public Category category { get; set; }
        public Product product { get; set; }
        #endregion
    }
}
