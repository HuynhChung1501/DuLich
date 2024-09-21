using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.Enums
{
    public class PhuongTienEnum
    {
        public enum TinhTrang
        {
            [Description("Mới")]
            Moi = 0,
            [Description("Cũ")]
            Cu = 1,
            [Description("Hỏng")]
            Hong = 2,
        }

        public enum LoaiPhuongTien
        {
            [Description("OTo")]
            Oto = 0,
            [Description("Máy bay")]
            MayBay = 1,
            [Description("Xe máy")]
            XeMay = 2,
            [Description("Tàu hỏa")]
            TauHoa = 3,
            [Description("Thuyền")]
            Thuyen = 4,
        }
    }
}
