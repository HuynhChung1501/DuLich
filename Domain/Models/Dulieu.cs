using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulich.Domain.Models
{
    [Table("Dulieu")]
    public class Dulieu : BaseModel
    {
        public string Name { get; set; }

    }
}
