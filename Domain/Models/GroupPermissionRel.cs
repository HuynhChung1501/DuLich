using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dulich.Domain.Models;

namespace Travel.Domain.Models
{
    [Table("Group_permission_rel")]
    public class GroupPermissionRel : BaseModel
    {
        [Description("Trường id bảng Permission")]
        [DisplayName("Permission_Id")]
        public int Permission_id { get; set; }

        [Description("Trường id bảng Group Permission ")]
        [DisplayName("Group_Permission_Id")]
        public int Group_permission_id { get; set; }
    }
}
