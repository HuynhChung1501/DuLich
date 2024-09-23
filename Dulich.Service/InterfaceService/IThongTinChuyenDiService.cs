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
        Task<List<ThongTinChuyenDi>> Search(string? searchMeta);
        Task<string> Delete(int id);
        Task<string> Deletes(int[] ids);
        Task<ThongTinChuyenDi> update(ThongTinChuyenDi chuyenDi);
        Task<ThongTinChuyenDi> Create(ThongTinChuyenDi chuyenDi);
    }
}
