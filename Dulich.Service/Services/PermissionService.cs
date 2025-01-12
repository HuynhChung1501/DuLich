using AutoMapper;
using Dulich.Application.ViewModels;
using Dulich.Domain.Interface;
using Dulich.Domain.Models;
using Dulich.Infrastructure;
using Dulich.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.Contansts;
using Travel.Application.Enums;
using Travel.Application.Helpers;
using Travel.Application.InterfaceService;
using Travel.Domain.CustomModels;
using Travel.Domain.Interface;
using Travel.Domain.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Travel.Application.Services
{
    public class PermissionService : BaseMasterService, IPermissionService
    {
        private readonly IMapper _mapper;
        private readonly DASContext _DasContext;

        public PermissionService(ITravelRepositoryWrapper travelRepository, IMapper mapper, DASContext dASContext) : base(travelRepository)
        {
            _mapper = mapper;
            _travelRepo = travelRepository;
            _DasContext = dASContext;

        }

        #region Get
        public async Task<List<Permission>> Search(string? searchMeta)
        {
            var chuyenDi = await (from M in _travelRepo.PermissionReponsitory.GetAll().AsNoTracking()
                                  where (string.IsNullOrEmpty(searchMeta) || M.Name.Contains(searchMeta))
                                  orderby M.ID descending
                                  select M).ToListAsync();
            if (!chuyenDi.Any()) throw new KeyNotFoundException("Không tìm thấy dữ liệu phù hợp");

            return chuyenDi;
        }
        public async Task<Permission> GetByid(int id)
        {
            try
            {
                var permission = await _travelRepo.PermissionReponsitory.FirstOrDefaultAsync(x => x.ID == id);
                if (permission == null) throw new AppException("Chức năng không tồn tại hoặc đã bị xóa");
                return permission;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }

        }

        #endregion


        #region Create
        public async Task<Permission> Create(Permission permission)
        {
            try
            {
                 await _DasContext.AddAsync(permission);
                 await _DasContext.SaveChangesAsync();
                return permission;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        #endregion

        #region Update
        public async Task<Permission> update(Permission model)
        {
            try
            {
                var permission = await _travelRepo.PermissionReponsitory.FirstOrDefaultAsync(x => x.ID == model.ID);

                if (permission == null)
                {
                    throw new AppException("Quyền hiện không tồn tại hoặc đã bị xóa");
                }
                _mapper.Map(model, permission);
                _DasContext.Permissions.Update(permission);
                _DasContext.SaveChanges();
                return permission;
            }
            catch (Exception e)
            {

                throw new AppException(e.Message);
            }

        }
        #endregion


        #region Delete

        
        public async Task<string> Delete(int id)
        {
            try
            {
                var chucNang = await _travelRepo.PermissionReponsitory.FirstOrDefaultAsync(x => x.ID == id);
                if (chucNang == null) throw new AppException("Chức năng không tồn tại hoặc đã bị xóa");

                _travelRepo.PermissionReponsitory.Delete(chucNang);
                _DasContext.SaveChanges();
                return $"Xóa Chức năng: {chucNang.Name} thành công";
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
        #endregion


    }
}
