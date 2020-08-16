using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = _userRepository.GetUserForLogin(login.Email.ToLower(), login.Password);
            if (user == null)
            {
                ModelState.AddModelError("Email","اطلاعات صحیح نیست");
                return View(login);
            }
            //گرفتن اطلاعات کاربر جاری
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Email),

            };
            //نوع اهراز هویت استفاده شده
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            
            var prinpical = new ClaimsPrincipal(identity);
            var propertis = new AuthenticationProperties
            {
                //لاگین بماند تا وقتی تیک من را به خاطر بسپار را بزند
                IsPersistent = login.RememberMe
            };
             HttpContext.SignInAsync(prinpical, propertis);
            //صفحه اصلی سایت
            return Redirect("/");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
    }
}
