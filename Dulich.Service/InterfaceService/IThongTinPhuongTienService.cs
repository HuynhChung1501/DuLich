using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.CustomModels;
using Travel.Domain.Models;

namespace Dulich.Service.Interface
{
    public interface IThongTinPhuongTienService
    {
        Task<ThongTinPhuongTien> Get(int id);
        Task<List<ThongTinPhuongTien>> Search(string? searchMeta);
        Task<string> Delete(int id);
        Task<string> Deletes(int[] ids);
        Task<ThongTinPhuongTien> update(ThongTinPhuongTien vmmenu);
        Task<ThongTinPhuongTien> Create(ThongTinPhuongTien menu);
    }
}
