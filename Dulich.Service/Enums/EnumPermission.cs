using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.Enums
{
    public enum EnumModule
    {
        [Description("Quản lý tài khoản")]
        Account = 1,
        [Description("Quản Menu")]
        Menu = 2,
        [Description("Quản lý đặt Tour")]
        DatTour = 3,
        [Description("Quản lý Khách sạn")]
        KhachSan = 4,
        [Description("Quản lý thông tin di chuyển")]
        ThongTinDiChuyen = 5,
        [Description("Quản lý thông tin phương tiện")]
        ThongTinChuyenDi = 6,
        [Description("Quản lý Tour")]
        Tour = 7,
    }
    public enum EnumPermission
    {
        [Description("Xem")]
        Read = 1,
        [Description("Tạo mới")]
        Create = 2,
        [Description("Chỉnh sửa")]
        Update = 3,
        [Description("Xóa")]
        Delete = 4,

    }
}
