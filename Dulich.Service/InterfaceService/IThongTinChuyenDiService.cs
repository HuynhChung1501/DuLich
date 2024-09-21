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
    public interface IThongTinChuyenDiService
    {
        Task<ThongTinChuyenDi> Get(int id);
        Task<List<ThongTinChuyenDi>> GetList();
        Task<VMThongTinChuyenDi> GetVmThongTinPhuongTien(int id);
        Task<ServiceResult> Delete(int id);
        Task<ServiceResult> Deletes(int[] ids);
        Task<ServiceResult> update(ThongTinChuyenDi vmmenu);
        Task<ServiceResult> Create(ThongTinChuyenDi menu);
    }
}
