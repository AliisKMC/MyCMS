using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [MaxLength(255)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "لطفا ایمیل را وارد کنید")]
        [MaxLength(255)]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
        [MaxLength(255)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "پسوردت امن نیست")]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا تکرار کلمه عبور را وارد کنید")]
        [MaxLength(255)]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }
}
