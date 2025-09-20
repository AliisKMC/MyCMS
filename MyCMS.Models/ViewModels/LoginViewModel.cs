using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا ایمیل یا نام کاربری را وارد کنید")]
        public string EmailOrUserName { get; set; }

        [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }
    }
}
