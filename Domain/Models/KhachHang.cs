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
    [Table("KhachHang")]
    public class KhachHang: BaseModel
    {
        [Description("ID thông tin khách hàng")]
        public int IDThongTinKhachHang { get; set; }

        [Description("id đặt tour")]
        public int IDDatTour { get; set; }

        [Description("id lich sử đặt tour")]
        public int IDLichSuDatTour { get; set; }

        [Description("mức độ")]
        public int MucDo { get; set; }
    }
}
