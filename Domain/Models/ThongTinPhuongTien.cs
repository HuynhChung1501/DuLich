using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Domain.Models
{
    [Table("ThongTinPhuongTien")]
    public class ThongTinPhuongTien : BaseModel
    {
        [Required]
        [MaxLength(250)]
        public required string Ten { get; set; }

        [Required]
        public required int LoaiPhuongTien { get; set; } = 0; //PhuongTienEnum.LoaiPhuongTien

        [Required]
        public required string Code { get; set; }

        public string? ChoNgoi { get; set; }

        public string? BienSoXe { get; set; }

        [MaxLength(2000)]
        public string? Mota { get; set; }

        public string? MauXe { get; set; }

        public string? HangXe { get; set; }

        public required int TinhTrang { get; set; } = 0 ; //mặc định là trạng thái mới

        public int IsActive { get; set; } = 1;

    }
}
