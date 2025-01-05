using Dulich.Application.ViewModels;
using Travel.Domain.Models;

namespace Travel.Application.InterfaceService
{
    public interface IPhanQuyenService 
    {
        Task<PhanQuyen> GetByMa(int MaPhanQuyen);
        Task<List<Permission>> GetRolesByUser(int idUser);
        Task<string> Delete(int id);
        Task<string> Deletes(int[] ids);
        Task<VMPhanQuyen> update(VMPhanQuyen model);
        Task<PhanQuyen> Create(PhanQuyen model);
    }
}
