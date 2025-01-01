using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Travel.Domain.Models
{
    [Table("Permission")]
    [Description("Chức năng")]
    public class Permission
    {
        [Key]
        [Description("Mã chức năng")]
        [Required]
        public required string MaChucNang { get; set; }
        [Description("Tên chức năng")]
        [Required]
        public required string TenChucNang { get; set; } 
        [Description("Nhóm chức năng")]
        public string? NhomChucNang { get; set; } 
    }
}
