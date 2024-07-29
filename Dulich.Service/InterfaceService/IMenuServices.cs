using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulich.Service.Interface
{
    public interface IMenuServices 
    {
        Task<Menu> Get(int id);
        Task<List<VMMenu>> GetList();
        Task<List<VMMenu>> SearchByCondition(string searchName);
    }
}
