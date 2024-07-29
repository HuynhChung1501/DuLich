using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Domain.Models
{
    public class JsonData
    { 
        public string Status {  get; set; }

        public string Message { get; set; }

        public Hashtable Data{ get; set; }
    }
}
