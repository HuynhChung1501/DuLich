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
        Task<Menu> Get(int id);
        Task<List<Menu>> GetList();
        Task<List<VMMenu>> SearchByCondition(string searchName);
        Task<VMMenu> GetVmMenu(int id);
        Task<ServiceResult> Delete(int id);
        Task<ServiceResult> Deletes(int[] ids);
        Task<ServiceResult> update(Menu vmmenu);
        Task<ServiceResult> Create(Menu menu);
    }
}
