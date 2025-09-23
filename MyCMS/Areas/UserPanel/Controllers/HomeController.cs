using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCMS.DataAccess.Services;
using MyCMS.Models.ViewModels;
using MyCMS.Utilities.Security;
using System.Security.Claims;

namespace MyCMS.Areas.UserPanel.Controllers
{ 
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _UserService;
        public HomeController(IUserService userService)
        {
            _UserService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region ChangePassword
        public IActionResult ChangePassword() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel vmPasswordViewModel)
        {
            if (!ModelState.IsValid) 
                return View(vmPasswordViewModel);

            string strCurrentUser=User.FindFirstValue("UserId");
            int intUserID = 0;

            if (strCurrentUser != null)
                intUserID = int.Parse(strCurrentUser);
            else
                throw new Exception("User Not Fount ...!");
            var user=_UserService.GetById(intUserID);
            if (!PasswordHasher.VerifyHashedPassword(user.Password,vmPasswordViewModel.OldPassword))
            {
                ModelState.AddModelError("", "کلمه عبور فعلی صحیح نمی باشد");
                return View(vmPasswordViewModel);
            }

            user.Password = PasswordHasher.HashPassword(vmPasswordViewModel.Password);
            _UserService.Update(user);

            return Redirect("/Account/Logout");
        }
        #endregion
    }
}
