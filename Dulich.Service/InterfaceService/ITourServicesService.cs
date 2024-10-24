using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.ViewModels;
using Travel.Domain.CustomModels;
using Travel.Domain.Models;

namespace Dulich.Service.Interface
{
    public interface ITourServicesService
    {
        Task<Tour> Get(int id);
        Task<List<Tour>> Search(string? searchMeta);
        Task<string> Delete(int id);
        Task<string> Deletes(int[] ids);
        Task<Tour> update(VMTour model);
        Task<Tour> Create(Tour model);
    }
}
