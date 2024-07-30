using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.CustomModels;

namespace Dulich.Service.Interface
{
    public interface IMenuServices 
    {
        Task<VMMenu> Get(int id);
        Task<List<VMMenu>> GetList();
        Task<List<VMMenu>> SearchByCondition(string searchName);
        Task<bool> Delete(int id);
        Task<bool> Deletes(int[] ids);
        Task<bool> update(VMMenu vmmenu);
    }
}
