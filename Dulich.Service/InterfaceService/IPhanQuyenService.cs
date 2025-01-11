using Dulich.Application.ViewModels;
using Travel.Domain.Models;

namespace Travel.Application.InterfaceService
{
    public interface IPhanQuyenService 
    {
        Task<List<PhanQuyen>> Search(string? searchMeta);
        Task<PhanQuyen> GetById(int id);
        Task<List<Permission>> GetRolesByUser(int idUser);
        Task<string> Delete(int id);
        Task<string> Deletes(int[] ids);
        Task<PhanQuyen> update(PhanQuyen model);
        Task<PhanQuyen> Create(PhanQuyen model);
    }
}
