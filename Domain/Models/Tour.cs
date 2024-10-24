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
    [Table("Tour")]
    public class Tour : BaseModel
    {
        [Description("Tên Tour")]
        [Required]
        public required string TenTour { get; set; }

        [Description("Tên Tour")]
        public int IDThongtinChuyenDi { get; set; }

        [Description("Lịch trình chuyến đi")]
        public string? LichTrinh { get; set; }

        [Description("Thông tin cần lưu ý")]
        public string? ThongTinLuuY { get; set; }

        [Description("Ngày đi")]
        public DateTime? NgayDi { get; set; }

        [Description("Tổng giá ")]
        public decimal TongGia { get; set; }

        [Description("Khuyến mại")]
        public decimal Khuyenmai { get; set; }

        [Description("Thời gian")]
        public string? ThoiGian { get; set; }

        [Description("Khởi hành")]
        public int KhoiHanh { get; set; }
        
        [Description("Chỗ ngồi còn lại")]
        public int ChoNgoi { get; set; }
        
        [Description("Album")]
        public string? Album { get; set; }

        [Description("Trạng thái")]
        public int IsActive { get; set; } = 1;
    }
}
