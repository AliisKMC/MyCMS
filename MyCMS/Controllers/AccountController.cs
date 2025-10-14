using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MyCMS.DataAccess.Services;
using MyCMS.Models.Model;
using MyCMS.Models.ViewModels;
using MyCMS.Utilities.Security;
using System.Security.Claims;

namespace MyCMS.Controllers
{
    public class AccountController : Controller
    {       
        IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel vmLogin)
        {
            if(!ModelState.IsValid)
                return View(vmLogin);

            var user1 = _userService.GetUserByUsernameOrEmail(vmLogin.EmailOrUserName);
            if (user1 == null)
            {
                ModelState.AddModelError("EmailOrUserName", "کاربری یافت نشد!");
                return View(vmLogin);
            }

            if(!PasswordHasher.VerifyHashedPassword(user1.Password,vmLogin.Password))
            {
                ModelState.AddModelError("EmailOrUserName", "کاربری یافت نشد!");
                return View(vmLogin);
            }
                      

            //TODO Login
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user1.UserName),
                new Claim("UserId",user1.Id.ToString()),
                new Claim("IsAdmin",user1.IsAdmin.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = vmLogin.RememberMe 
            };

            HttpContext.SignInAsync(principal, properties);
            return Redirect("/");            
        }
        #endregion

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel vmRegister)
        {
           if(!ModelState.IsValid)
                return View(vmRegister);
            if (_userService.IsExistUsername(vmRegister.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری وارد شده معتبر نیست");
                return View(vmRegister);
            }
            if(_userService.IsExistEmail(vmRegister.Email))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده معتبر نیست");
                return View(vmRegister);
            }

            User user = new User();
            user.UserName = vmRegister.UserName;
            user.Password = PasswordHasher.HashPassword(vmRegister.Password);
            user.Email = vmRegister.Email.ToLower().Trim();            
            user.CreateDate= DateTime.Now;
            user.IsDelete = false;
            user.IsAdmin = false;
            _userService.Add(user);
                
            return View("SuccessRegister",user);
        }
        #endregion

        #region Log Out
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}
