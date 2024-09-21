using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.ViewModels
{
    public class VMAccount : BaseModel
    {
        [MaxLength(50)]
        public string? UsereName { get; set; }

        [MaxLength(50)]
        public string? PassWord { get; set; }

        [MaxLength(150)]
        public string? FullName { get; set; }

        public bool? Gender { get; set; }

        [MaxLength(150)]
        public string? Email { get; set; }

        [MaxLength(150)]
        public string? Phone { get; set; }

        [DefaultValue("1")]
        public int Active { get; set; } = 1;
    }
}
