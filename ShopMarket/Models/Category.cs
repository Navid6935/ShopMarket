using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMarket.Models
{
    public class Category
    {
        public int id { get; set; }          
        public string Name { get; set; }          
        public string Discription { get; set; }

        #region Relation
        //Navogation Property
        //رابطه یک به چند
        public ICollection<CategorytoProduct> categorytoProducts { get; set; }
        #endregion
    }
}
