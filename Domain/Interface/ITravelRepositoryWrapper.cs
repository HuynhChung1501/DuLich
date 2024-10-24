using Dulich.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Domain.Interface
{
    public interface ITravelRepositoryWrapper
    {
        IMenuRepository Menu { get; }
        IThongTinPhuongTienRepository ThongTinPhuongTien { get; }
        IThongTinChuyenDiRepository ThongTinChuyenDi { get; }
        IDatPhongRepository DatPhongRepository { get; }
        IKhachSanRepository KhachSanRepository { get; }
        ILoaiPhongRepository LoaiPhongRepository { get; }
        IPhongKSRepository PhongKSRepository { get; }
        ITienIchPhongRepository TienIchPhongRepository { get; }
        IAccountRepository Account { get; }
        ITourRepository TourRepository { get; }

    }
}
