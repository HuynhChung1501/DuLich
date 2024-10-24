using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.ViewModels;
using Travel.Domain.CustomModels;

namespace Dulich.Service.Interface
{
    public interface IMenuServices
    {
        Task<Menu> Get(int id);
        Task<List<Menu>> Search(string? searchMeta);
        Task<string> Delete(int id);
        Task<string> Deletes(int[] ids);
        Task<Menu> update(VMMenu model);
        Task<Menu> Create(Menu model);
    }
}
