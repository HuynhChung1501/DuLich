using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dulich.Domain.Models
{
    [Table("PhongKS")]
    public class PhongKS : BaseModel
    {
        [Description("Phòng khách sạn")]
        [Required]
        public string Name { get; set; }

        [Description("ID khách sạn")]
        [Required]
        public int IDHotel { get; set; }

        [Description("ID loại phòng")]
        [Required]
        public int IDTypeRoom { get; set; }

        [Description("Độ rộng")]
        [MaxLength(50)]
        public string? Acreage { get; set; }

        [Description("Số lượng khách")]
        public string? CountGuest { get; set; }

        public int Active { get; set; } = 1;
    }
}
