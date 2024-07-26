using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dulich.Domain.Models
{
    [Table("ThongTinPhuongTien")]
    public class ThongTinPhuongTien : BaseModel
    {

        [Description("Tên Phương tiện")]
        [Required]
        public string Name { get; set; }

        [Description("Loại phương tiện")]
        public int Type { get; set; }

        [Description("Mã phương tiện")]
        [Required]
        [MaxLength(50)]
        public int Code { get; set; }

        [Description("Chỗ ngồi")]
        public int Seating { get; set; }

        [Description("Biển số xe")]
        [Required]
        public string LicensePlates { get; set; }

        [Description("Màu sắc")]
        public string Color { get; set; }

        [Description("Hãng sản xuất")]
        public string Manufacturer { get; set; }

        [Description("Trạng thái sử dụng")]
        public int Status { get; set; } = 0;

        [Description("Mô tả")]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Description("Hoạt động")]
        [Required]
        public int Active { get; set; }
    }
}
