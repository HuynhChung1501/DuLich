using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Dulich.Domain.Models;

namespace Dulich.Service.Interface
{
    public interface IMenu
    {
        MenuModel GetAll();
    }
}
