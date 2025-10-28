using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Models.Model
{

    public class Page :BaseEntity
    {
        [Display(Name = "گروه خبر")]
        public int GroupId { get; set; }

        [Display(Name = "عنوان خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد.")]
        public string Title { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400)]
        public string ShortDescription { get; set; }

        [Display(Name = "محتوا")]
        public string Content { get; set; }

        [Display(Name = "بازدید")]
        public int Visit { get; set; }

        [Display(Name = "تصویر")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد.")]
        public string? ImageName { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد.")]
        public string Tags { get; set; }

        [Display(Name = "نمایش در اسلایدر")]
        public bool ShowInSlider { get; set; }

        [ForeignKey("GroupId")]
        //[Display(Name = "گروه خبری مربوطه")]
        public PageGroup? PageGroup { get; set; }
    }
}
