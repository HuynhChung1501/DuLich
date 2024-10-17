using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Domain.Models
{
    [Table("LichSuTour")]
    public class LichSuTour: BaseModel
    {
        [Description("ID khách hàng")]
        public int IDKhachhang { get; set; }

        [Description("ID Đặt tour")]
        public int IDDatTour { get; set; }

        [Description("Trạng thái tour")]
        public int TrangThai { get; set; }
    }
}
