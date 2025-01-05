using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Dulich.Domain.Models;

namespace Travel.Domain.Models
{
    [Table("Permission")]
    [Description("Chức năng")]
    public class Permission : BaseModel
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
