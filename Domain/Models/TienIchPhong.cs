﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dulich.Domain.Models
{
    [Table("TienIchPhong")]
    public class TienIchPhong : BaseModel
    {
        [Description("Số lượng giường")]
        public int? CountBed { get; set; }

        [Description("Nóng lạnh")]
        public bool NongLanh { get; set; }

        [Description("Điều hòa")]
        public bool DieuHoa { get; set; }
        
        [Description("Tủ lạnh")]
        public bool TuLanh { get; set; }

        [Description("Tiện ích nâng cao")]
        [MaxLength(1000)]
        public string? TienIchNangCao { get; set; }
    }
}
