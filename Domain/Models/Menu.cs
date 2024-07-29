
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dulich.Domain.Models
{
    [Table("Menu")]
    public class Menu : BaseModel   
    {
        [Description("Tên menu")]
        [Required]
        public string Name { get; set; }

        [Description("Đường dẫn")]
        [Required]
        public string Url { get; set; }

        [Description("Icon")]
        public string Icon { get; set; }

        [Description("ID cấp cha")] // nếu ib khác 0 thì là cấp con
        public int IDParent { get; set; } = 0;
    }
}
