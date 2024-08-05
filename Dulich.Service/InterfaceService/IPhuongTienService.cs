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
    public interface IPhuongTienService
    {
        Task<PhuongTien> Get(int id);
        Task<List<PhuongTien>> GetList();
        Task<VMPhuongTien> GetVmThongTinPhuongTien(int id);
        Task<ServiceResult> Delete(int id);
        Task<ServiceResult> Deletes(int[] ids);
        Task<ServiceResult> update(PhuongTien vmmenu);
        Task<ServiceResult> Create(PhuongTien menu);
    }
}
