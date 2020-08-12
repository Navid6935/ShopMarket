using ShopMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMarket.Data.Repositoreis
{
    public interface IGroupRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
    public class GroupRepository : IGroupRepository
    {
        public MarketShopContext _context;

        public GroupRepository(MarketShopContext context)
        {
            _context = context; 
        }
        public IEnumerable<Category> GetAllCategories()
        {
           return _context.cateories.ToList();
        }
    }
}
