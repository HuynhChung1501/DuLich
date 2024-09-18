using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Domain.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public Object? Data { get; set; }    
    }
}
