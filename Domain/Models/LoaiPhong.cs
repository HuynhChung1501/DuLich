using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dulich.Domain.Models
{
    [Table("LoaiPhong")]
    public class LoaiPhong : BaseModel
    {
        [Description("Tên loại phòng")]
        [Required]
        public string Name { get; set; }

        [Description("ID khách sạn")]
        [Required]

        public int IDHotel { get; set; }

        [Description("ID phòng khách sạn")]
        [Required]
        public int IDRoom { get; set; }

        [Description("ID Tiện ích")]
        [Required]
        public int IDUtilities { get; set; }

        public int Active { get; set; } = 1;
    }
}
