using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Domain.Models
{
    [Table("PhanQuyen")]
    public class PhanQuyen : BaseModel
    {
        [Description("ID Account")]
        [Required]
        public required int IDAccount { get; set; }

        [Description("Mã chức năng")]
        [Required]
        public required string MaChucNang { get; set; }

        [Description("Mô tả")]
        public string? MoTa { get; set; }
    }
}
