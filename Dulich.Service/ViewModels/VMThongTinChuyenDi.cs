﻿using Dulich.Domain.Models;
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
    public class VMThongTinChuyenDi : BaseModel
    {
        [Description("Chiều di chuyển")]
        [Required]
        public string Name { get; set; }

        [Description("Thời gian khởi hành")]
        [Required]
        public DateTime StartDate { get; set; }

        [Description("Địa điểm đón khách")]
        public string? PickupLocation { get; set; }

        [Description("ID Phương tiện")]
        public string? IDTransport { get; set; }

        [Description("Chỗ ngồi")]
        public int? Seating { get; set; }

        [Description("Mô tả")]
        [MaxLength(2000)]
        public string? Description { get; set; }

        [Description("ID Tour")]
        public int? IDTour { get; set; }

        public List<ThongTinChuyenDi> ThongTinChuyenDis { get; set; }
        public ThongTinChuyenDi thongTinChuyenDi { get; set; }
    }
}