using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Domain.Models
{
    [Table("DiaDiemDuLich")]
    public class DiaDiemDuLich : BaseModel
    {
        [Description("Tên địa điểm")]
        [Required]
        [MaxLength(250)]
        public string? Ten { get; set; }

        [Description("Code Tỉnh/Thành phố")]
        public int CodeThanhPho { get; set; }

        [Description("Code Quận/Huyện")]
        public int CodeHuyen { get; set; }

        [Description("Code Phường/Xã")]
        public int CodeXa { get; set; }

        [Description("Giá cũ")]
        public decimal GiaCu { get; set; }

        [Description("Giá mới")]
        public decimal GiaMoi { get; set; }

        [Description("Giờ mở cửa")]
        public DateTime GioMoCua { get; set; }

        [Description("Giờ đóng cửa")]
        public DateTime GioDongCua { get; set; }

        [Description("Mô tả")]
        public string? MoTa { get; set; }

    }
}
