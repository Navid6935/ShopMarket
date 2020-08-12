using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Data.Repositoreis;
using ShopMarket.Models;

namespace ShopMarket.Controllers
{
    public class AccountController1 : Controller
    {
        private IUserRepository _userRepository;

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Register(AccountViewModels.RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            if (_userRepository.ISExistByEmail(register.Email.ToLower()))
            {
                ModelState.AddModelError("Email","ایمیل وارد شده قبلا ثبت نام کرده است");
                return View();
            }

            Users user = new Users()
            {
                Email = register.Email.ToLower(),
                Password = register.Password,
                IsAdmin = false
            };
            _userRepository.AddUser(user);

            return View("SuccessRegister",register);
        }
    }
}
