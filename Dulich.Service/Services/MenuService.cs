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
using System.Text;
using System.Threading.Tasks;
using Travel.Application.Contansts;
using Travel.Application.Services;
using Travel.Domain.CustomModels;
using Travel.Domain.Interface;

namespace Dulich.Service.Service
{
    public class MenuService : BaseMasterService, IMenuServices
    {
        private readonly IMapper _mapper;
        private readonly DASContext _DasContext;

        public MenuService(ITravelRepositoryWrapper travelRepository, IMapper mapper, DASContext dASContext) : base(travelRepository)
        {
            _mapper = mapper;
            _travelRepo = travelRepository;
            _DasContext = dASContext;

        }

        public async Task<ServiceResult> Create(Menu menu)
        {
            if (menu == null)
            {
                return new ServiceResultError("Thêm mới không thành công");
            }
            var valid = await validation(menu);
            if (valid.Code == CommonConst.Success)
            {
                _DasContext.Add(menu);
                _DasContext.SaveChanges();
                return valid;
            }
            else {
                validation(menu);
            }
            return valid;

        }

        public async Task<ServiceResult> Delete(int id)
        {
            try
            {
                var menu = _travelRepo.Menu.Get(id);
                if (menu == null)
                {
                    return new ServiceResultError("Menu không tồn tại");
                }

                _travelRepo.Menu.Delete(menu);
                _DasContext.SaveChanges();
                return new ServiceResultSuccess("Xóa Menu thành công");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ServiceResult> Deletes(int[] ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    var rs = await Delete(id);
                    if (rs.Code == CommonConst.error)
                    {
                        return new ServiceResultError($"ID: {id} không tồn tại");

                    }
                }
                return new ServiceResultSuccess("Xóa thành công");

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<VMMenu> Get(int id)
        {
            var rs = await _travelRepo.Menu.FirstOrDefaultAsync(x => x.ID == id);
            VMMenu vmMenu = new VMMenu();
            _mapper.Map(rs, vmMenu);
            return vmMenu;
        }

        public async Task<List<Menu>> GetList()
        {
            var menu = await (from M in _travelRepo.Menu.GetAll().AsNoTracking()
                              select M).ToListAsync();
            return menu;
        }

        public async Task<List<VMMenu>> SearchByCondition(string searchName)
        {
            var menu = await (from M in _travelRepo.Menu.GetAll().AsNoTracking()
                              where searchName != null ? searchName.ToLower() == M.Name.ToLower() : true
                              select new VMMenu
                              {
                                  Name = M.Name,
                                  ID = M.ID,
                                  Url = M.Url,
                                  Icon = M.Icon,
                                  IDParent = M.IDParent,
                              }).ToListAsync();
            return menu;
        }

        public async Task<bool> update(VMMenu vmmenu)
        {
            var menu = await _travelRepo.Menu.GetAsync(vmmenu.ID);
            if (menu == null)
            {
                return false;
            }
            _mapper.Map(vmmenu, menu);
            _travelRepo.Menu.UpdateAsync(menu);
            _DasContext.SaveChanges();
            return true;
        }

        public async Task<ServiceResult> validation(Menu menu)
        {
            if (menu.Name == string.Empty)
            {
                return new ServiceResultError("Tên không được bỏ trống");
            }
            if (menu.Url == string.Empty)
            {
                return new ServiceResultError("Đường đẫn không được bỏ trống");
            }
            return new ServiceResultSuccess("Thêm mới thành công");
        }
    }
}
