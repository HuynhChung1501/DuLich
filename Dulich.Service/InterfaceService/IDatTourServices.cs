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
    public interface IDatTourServices
    {
        Task<DatTour> Get(int id);
        Task<List<DatTour>> Search(string? searchMeta);
        Task<string> Delete(int id);
        Task<string> Deletes(int[] ids);
        Task<DatTour> Update(DatTour model);
        Task<DatTour> Create(DatTour model);
        Task<string> UpdateTrangThai(int idDatTour, int trangThai);
    }
}
