using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dulich.Domain.Models
{
    [Table("DatPhong")]
    public class DatPhong : BaseModel
    {
        [Description("ID khách sạn")]
        [Required]
        public int IDHotel { get; set; }

        [Description("ID phòng khách sạn")]
        [Required]
        public int IDRoom { get; set; }

        [Description("Số lượng khách")]
        public int? CountGuest { get; set; }

        [Description("Giá cũ")]
        public int? PriceOld { get; set; }

        [Description("Giá mới")]
        public int? PriceNew { get; set; }

        public int Active { get; set; } = 1;
    }
}
