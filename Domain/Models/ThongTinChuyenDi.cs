using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dulich.Domain.Models
{
    [Table("ThongTinChuyenDi")]
    public class ThongTinChuyenDi : BaseModel
    {
        [Description("Chiều di chuyển")]
        [Required]
        public required string Name { get; set; }

        [Description("Thời gian khởi hành")]
        [Required]
        public DateTime? GioKhoiHanh { get; set; }

        [Description("Địa điểm đón khách")]
        public string? DiemDon { get; set; }

        [Description("Giờ trả khách")]
        public DateTime? GioTraKhach { get; set; }

        [Description("Địa điểm trả khách")]
        public string? DiemTraKhach { get; set; }

        [Required]
        [Description("ID Phương tiện")]
        public required int IDPhuongTien { get; set; }

        [Description("Chỗ ngồi")]
        public int? ChoNgoi { get; set; }

        [Description("Mô tả")]
        [MaxLength(2000)]
        public string? MoTa { get; set; }

        [Description("ID Tour")]
        public int? IDTour { get; set; }

        [Description("Hiện đang hoạt động")]
        public int IsActive { get; set; } = 1; 
        
    }
}
