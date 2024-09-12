using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Dulich.Application.ViewModels
{
    public class VMPhuongTien : BaseModel
    {
        [Description("Tên Phương tiện")]
        public string Name { get; set; }

        [Description("Loại phương tiện")]
        public int Type { get; set; }

        [Description("Mã phương tiện")]
        public int Code { get; set; }

        [Description("Chỗ ngồi")]
        public int Seating { get; set; }

        [Description("Biển số xe")]
        public string LicensePlates { get; set; }

        [Description("Màu sắc")]
        public string? Color { get; set; }

        [Description("Hãng sản xuất")]
        public string? Manufacturer { get; set; }

        [Description("Trạng thái sử dụng")]
        public int Status { get; set; } = 0;

        [Description("Mô tả")]
        public string? Description { get; set; }

        [Description("Hoạt động")]
        public int Active { get; set; }

        public List<PhuongTien> PhuongTiens { get; set; }
        public PhuongTien PhuongTien { get; set; }
    }
}
