using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.Enums
{
    public class DatTourEnum
    {
        public enum TinhTrang
        {
            [Description("Chờ thanh toán")]
            ChoThanhToan = 0,
            [Description("Chờ xác nhận")]
            ChoXacNhan = 1,
            [Description("Đã thanh toán")]
            DaThanhToan = 2,
            [Description("Hủy booking")]
            HuyBooking = 3,
            [Description("Quá hạn thanh toán")]
            QuaHan = 4,
        }

    }
}
