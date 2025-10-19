using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Models.Model
{
    public class PageGroup : BaseEntity
    {
        [Display(Name = "نام گروه")]
        [Required(ErrorMessage = "{0} نمی تواند خالی باشد")]
        [MaxLength(200, ErrorMessage ="{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        public string GroupTitle{ get; set; }

    }
}
