using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Models.Model
{
    public class User:BaseEntity
    {
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [MaxLength(255)]
        public string UserName { get; set; }

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
        [MaxLength(255)]
        public string Password { get; set; }

        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "لطفا ایمیل را وارد کنید")]
        [MaxLength(255)]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }
        [DisplayName("ادمین است؟")]
        public bool IsAdmin { get; set; }

    }
}
