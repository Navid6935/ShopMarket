using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Models;

namespace ShopMarket.Data.Repositoreis
{
   public interface IUserRepository
   {
       bool ISExistByEmail(string email);
       Users GetUserForLogin(string Email, string password);
        void AddUser(Users users);

    }
    public class UserRepository : IUserRepository
    {
        private MarketShopContext _context;

        public UserRepository(MarketShopContext context)
        {
            _context = context;
        }



        public void AddUser(Users users)
        {
            _context.Add(users);
            _context.SaveChanges();
        }

        public bool ISExistByEmail(string email)
        {
            return _context.Userses.Any(u => u.Email == email);
        }
        public Users GetUserForLogin(string Email, string password)
        {
            return _context.Userses.SingleOrDefault(u => u.Email == Email && u.Password == password);    
        }
    }
}
