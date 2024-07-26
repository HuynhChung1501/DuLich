using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dulich.Domain.Models
{
    public class BaseModel
    {
        [Key]
        [Required]
        [Description("Khóa chính")]
        public int ID { get; set; }
        public int? CreatedBy { get; set; }   
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy {  get; set; }
    }
}
