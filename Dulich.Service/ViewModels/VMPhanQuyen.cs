using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Dulich.Application.ViewModels
{
    public class VMPhanQuyen : BaseModel
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
