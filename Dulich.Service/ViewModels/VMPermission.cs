using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.ViewModels
{
    public class VMPermission : BaseModel
    {
        [Description("Tên chức năng")]
        [Required]
        [MaxLength(250)]
        public required string Name { get; set; }
        [DisplayName("Module_Type")]
        [Description("Kiểu dữ liệu Module")]
        public int Module_type { get; set; }
        [DisplayName("Permission_Type")]
        [Description("Kiểu dữ liệu của Quyền")]
        public int Permission_type { get; set; }
        [Description("Mô tả")]
        public string Describe { get; set; } = string.Empty;
    }
}
