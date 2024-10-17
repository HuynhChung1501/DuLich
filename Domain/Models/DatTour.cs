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
    [Table("DatTour")]
    public class DatTour: BaseModel
    {
        [Description("ID thông tin khách hàng")]
        public int IDKhachhang { get; set; }

        [Description("id Tour")]
        public int IDTour { get; set; }

        [Description("Số lượng người lớn")]
        public int SLNguoiLon { get; set; }

        [Description("số lượng trẻ em")]
        public int SLTreEm { get; set; }

        [Description("Loại phương tiện")]
        public int LoaiPhuongTien { get; set; }

        [Description("Chỗ ngồi")]
        public string? ChoNgoi { get; set; }

        [Description("Ngày về")]
        public DateTime? NgayVe { get; set; }

        [Description("Ngày đi")]
        public DateTime? NgayDi { get; set; }

        [Description("Tổng số khách")]
        public int TongKhach { get; set; }

        [Description("Tổng giá ")]
        public decimal TongGia { get; set; }

        [Description("Khuyến mại")]
        public int Khuyenmai { get; set; }
    }
}
