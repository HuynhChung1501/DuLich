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
    [Table("Group_Permission")]
    public class GroupPermission : BaseModel
    {
        [Description("Tên nhóm quyền")]
        [MaxLength(250)]
        [Required]
        public required string Name { get; set; }

        [Description("Mô tả")]
        public string Describe { get; set; } = string.Empty;

        [Description("Trạng thái")]
        public int Status { get; set; } = 1;

    }
}
