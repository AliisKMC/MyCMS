using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Models.Model
{
    public class User:BaseEntity
    {
        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [MaxLength(255)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا ایمیل را وارد کنید")]
        [MaxLength(255)]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

    }
}
