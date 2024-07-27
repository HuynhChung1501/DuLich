using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulich.Domain.Models.ViewModel
{
    public class MenuVM
    {
        [Description("Tên menu")]
        [Required]
        public string Name { get; set; }

        [Description("Đường dẫn")]
        [Required]
        public string Url { get; set; }

        [Description("Icon")]
        public string icon { get; set; }

        [Description("ID cấp cha")] // nếu ib khác 0 thì là cấp con
        public int IDParent { get; set; } = 0;
    }
}
