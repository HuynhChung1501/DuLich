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
    [Table("DatTour")]
    public class DatTour: BaseModel
    {
        [Description("ID thông tin khách hàng")]
        public int IDKhachhang { get; set; }

        [Description("Họ tên khách hàng")]
        public string? Hoten { get; set; }

        [Description("Email khách hàng")]
        public string? Email { get; set; }
        
        [Description("Diện thoại khách hàng")]
        public string? DienThoai { get; set; }
        
        [Description("Địa chỉ khách hàng")]
        public string? ĐiaChi { get; set; }

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

        [Description("Tình trạng thanh toán ")]
        public int TinhTrang { get; set; }

        [Description("Khuyến mại")]
        public decimal Khuyenmai { get; set; }
    }
}
