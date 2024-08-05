using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dulich.Domain.Models
{
    [Table("KhachSan")]
    public class KhachSan : BaseModel
    {
        [Description("Tên khách sạn")]
        [Required]
        public string Name { get; set; }

        [Description("Phân khúc")]
        public int? Segment { get; set; }

        [Description("Đánh giá")]
        public string? Rating { get; set; }

        [Description("vote sao")]
        public int Vote { get; set; } = 1;

        [Description("Địa điểm")]
        public string? Location { get; set; }

        [Description("Tổng số phòng")]
        public int? TotalRoom { get; set; }

        [Description("Album ảnh")]
        public string? Album { get; set; }

        [Description("Giá cũ")]
        public int? PriceOld { get; set; }

        [Description("Giá mới")]
        public int? PriceNew { get; set; }

        [Description("Tiện ích")]
        public int? IDUtilities { get; set; }

        [Description("Mô tả")]
        [MaxLength(2000)]
        public string? Descrition { get; set; } 

        [Description("Hoạt động")]
        public int Active { get; set; } = 1;
    }
}
