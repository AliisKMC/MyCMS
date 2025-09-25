using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Models.Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }
        [DisplayName("تاریخ تغییر")]
        public DateTime? ModifiedDate { get; set; }
        [DisplayName("حذف شده؟")]
        public bool IsDelete { get; set; }

    }
}
