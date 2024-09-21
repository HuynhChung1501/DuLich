using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Domain.Models
{
    public class LoginModel
    {
        [Required]
        [MaxLength(50)]
        public required string UsereName { get; set; }

        [Required]
        [MaxLength(50)]
        public required string PassWord { get; set; }
    }
}
