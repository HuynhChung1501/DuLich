using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.ViewModels;

namespace Travel.Application.InterfaceService
{
    public interface IKhachSanService
    {
        Task<KhachSan> Get(int id);
        Task<List<KhachSan>> Search(string? searchMeta);
        Task<string> Delete(int id);
        Task<string> Deletes(int[] ids);
        Task<KhachSan> update(VMKhachSan model);
        Task<KhachSan> Create(KhachSan model);
    }
}
