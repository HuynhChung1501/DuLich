using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Travel.Domain.Models
{
    [Table("Account")]
    public class Account: BaseModel
    {
        [Required]
        [MaxLength(50)]
        public required string UsereName { get; set; }

        [Required]
        [MaxLength(50)]
        public required string PassWord { get; set; }

        [Required]
        [MaxLength(150)]
        public required string FullName { get; set; }

        public bool? Gender { get; set; }

        [MaxLength(150)]
        public string? Email { get; set; }

        [MaxLength(150)]
        public string? Phone { get; set; }

        [DefaultValue("1")]
        public int Active { get; set; } = 1;

    }
}
