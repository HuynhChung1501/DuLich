using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Domain
{
    [Table("ChucNang")]
    public class ChucNang
    {
        [Description("Tên chức năng")]
        public string? TenChucNang { get; set; }

        [Key]
        [Description("Mã chức năng")]
        [Required]
        public required string MaChucNang { get; set; }
        
        [Description("Mã chức năng")]
        public string? NhomChucNang { get; set; }

    }
}
