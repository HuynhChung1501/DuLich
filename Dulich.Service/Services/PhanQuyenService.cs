
using AutoMapper;
using Dulich.Application.ViewModels;
using Dulich.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Travel.Application.Helpers;
using Travel.Application.InterfaceService;
using Travel.Domain.Interface;
using Travel.Domain.Models;

namespace Travel.Application.Services
{
    public class PhanQuyenService : BaseMasterService, IPhanQuyenService
    {
        private readonly IMapper _mapper;
        private readonly DASContext _DasContext;
        private readonly IAccountService _accountService;

        public PhanQuyenService(IAccountService accountService, ITravelRepositoryWrapper travelRepository, IMapper mapper, DASContext dASContext) : base(travelRepository)
        {
            _mapper = mapper;
            _travelRepo = travelRepository;
            _DasContext = dASContext;
            _accountService = accountService;

        }

        public async Task<PhanQuyen> Create(PhanQuyen phanQuyen)
        {
            try
            {
                await _DasContext.AddAsync(phanQuyen);
                await _DasContext.SaveChangesAsync();
                return phanQuyen;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                var phanQuyen = await _travelRepo.PhanQuyenReponsitory.FirstOrDefaultAsync(x => x.ID == id);
                if (phanQuyen == null) throw new AppException("Thông tin không tồn tại hoặc đã bị xóa");

                _travelRepo.PhanQuyenReponsitory.Delete(phanQuyen);
                _DasContext.SaveChanges();
                return $"Xóa Phân Quyền thành công";
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public async Task<string> Deletes(int[] ids)
        {
            try
            {
                if (ids.Length == 0)
                {
                    throw new AppException($"Không có phần tử nào được xóa");
                }
                foreach (var id in ids)
                {
                    var rs = await Delete(id);
                }
                return ("Xóa thành công");

            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
        }

        public async Task<List<PhanQuyen>> Search(string? searchMeta)
        {
            try
            {
                var phanQuyen = await (from M in _travelRepo.PhanQuyenReponsitory.GetAll().AsNoTracking()
                                  where (string.IsNullOrEmpty(searchMeta) || M.MaChucNang.Contains(searchMeta))
                                  orderby M.ID descending
                                  select M).ToListAsync();
                if (!phanQuyen.Any()) throw new AppException("Không tìm thấy dữ liệu phù hợp");

                return phanQuyen;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }

        }

        public async Task<VMPhanQuyen> update(VMPhanQuyen model)
        {
            try
            {
                var phanQuyen = await (from m in _travelRepo.PhanQuyenReponsitory.GetAll()
                                  where m.ID == model.ID
                                  select m).FirstOrDefaultAsync();
                if (phanQuyen == null)
                {
                    throw new AppException("Thông tin hiện không tồn tại hoặc đã bị xóa");
                }
                _mapper.Map(model, phanQuyen);
                _DasContext.PhanQuyen.Update(phanQuyen);
                _DasContext.SaveChanges();
                _mapper.Map(phanQuyen, model);

                return model;
            }
            catch (Exception e)
            {

                throw new AppException(e.Message);
            }

        }

        public async Task<PhanQuyen> GetByMa(string MaPhanQuyen)
        {

            var phanQuyen = await (from m in _travelRepo.PhanQuyenReponsitory.GetAll()
                                 where m.MaChucNang == MaPhanQuyen
                                   select m).FirstOrDefaultAsync();

            if (phanQuyen == null)
            {
                throw new AppException("Dữ liệu không tồn tại hoặc đã bị xóa");
            }

            return phanQuyen;
        }
        public async Task<List<Permission>> GetRolesByUser(int idUser)
        {
            var user = await _travelRepo.Account.FirstOrDefaultAsync(x => x.ID == idUser);
            if (user == null) { 
                throw new AppException("Acount không tồn tại hoặc đã bị xóa");
            }
            var permissions = (from per in _travelRepo.PermissionReponsitory.GetAllList()
                               join pq in _travelRepo.PhanQuyenReponsitory.GetAll().Where(x => x.IDAccount == idUser)
                               on per.MaChucNang equals pq.MaChucNang
                               select per).ToList();

            if (permissions == null)
            {
                throw new AppException("Người dùng hiện không có quyền nào");
            }

            return permissions;
        }

    }
}
