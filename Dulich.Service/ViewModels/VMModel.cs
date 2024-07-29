using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulich.Application.ViewModels
{
    public class VMModel : BaseModel
    {
        [Description("Tên menu")]
        public string Name { get; set; }

        [Description("Đường dẫn")]
        public string Url { get; set; }

        [Description("Icon")]
        public string Icon { get; set; }

        [Description("ID cấp cha")] // nếu ib khác 0 thì là cấp con
        public int IDParent { get; set; }
    }
}
