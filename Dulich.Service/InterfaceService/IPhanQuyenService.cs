using Dulich.Application.ViewModels;
using Travel.Domain.Models;

namespace Travel.Application.InterfaceService
{
    public interface IPhanQuyenService 
    {
        Task<PhanQuyen> GetByMa(string MaPhanQuyen);
        Task<List<Permission>> GetRolesByUser(int idUser);
        Task<List<PhanQuyen>> Search(string? searchMeta);
        Task<string> Delete(int id);
        Task<string> Deletes(int[] ids);
        Task<VMPhanQuyen> update(VMPhanQuyen model);
        Task<PhanQuyen> Create(PhanQuyen model);
    }
}
