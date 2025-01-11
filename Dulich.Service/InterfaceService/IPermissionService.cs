using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.ViewModels;
using Travel.Domain.Models;

namespace Travel.Application.InterfaceService
{
    public interface IPermissionService
    {
        Task<List<Permission>> Search(string? searchMeta);
        Task<Permission> GetByid(int id);
        Task<string> Delete(int id);
        Task<string> Deletes(int[] ids);
        Task<Permission> update(Permission model);
        Task<Permission> Create(Permission model);
    }
}
