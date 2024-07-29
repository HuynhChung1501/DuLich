using Dulich.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Domain.Interface
{
    public interface ITravelRepositoryWrapper
    {
        IMenuRepository Menu { get; }
    }
}
