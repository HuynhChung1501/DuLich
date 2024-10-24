using Dulich.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Models;

namespace Travel.Domain.Interface
{
    public interface ITourRepository : IBaseRepository<Tour>
    {
    }
}
