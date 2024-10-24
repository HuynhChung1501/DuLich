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
using Travel.Application.ViewModels;
using Travel.Domain.CustomModels;
using Travel.Domain.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Travel.Application.Services
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

        public async Task<Menu> Create(Menu menu)
        {
            try
            {
                await _DasContext.AddAsync(menu);
                await _DasContext.SaveChangesAsync();
                return menu;
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
                var menu = await _travelRepo.MenuRepository.FirstOrDefaultAsync(x => x.ID == id);
                if (menu == null) throw new AppException("Menu không tồn tại hoặc đã bị xóa");

                _travelRepo.MenuRepository.Delete(menu);
                _DasContext.SaveChanges();
                return $"Xóa Menu: {menu.Name} thành công";
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

        public async Task<Menu> Get(int id)
        {
            try
            {
                var menu = await _travelRepo.MenuRepository.FirstOrDefaultAsync(x => x.ID == id);
                if (menu == null) throw new AppException("Menu không tồn tại hoặc đã bị xóa");
                return menu;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }

        }

        public async Task<List<Menu>> Search(string? searchMeta)
        {
            try
            {
                var menu = await (from M in _travelRepo.MenuRepository.GetAll().AsNoTracking()
                                  where (string.IsNullOrEmpty(searchMeta) || M.Name.Contains(searchMeta))
                                  && M.IsActive == (int)EnumCommon.Status.Active
                                  orderby M.ID descending
                                  select M).ToListAsync();
                if (!menu.Any()) throw new AppException("Không tìm thấy dữ liệu phù hợp");

                return menu;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }

        }

        public async Task<Menu> update(VMMenu model)
        {
            try
            {
                var menu = await (from m in _travelRepo.MenuRepository.GetAll()
                                  where m.ID == model.ID
                                  select m).FirstOrDefaultAsync();
                if (menu == null)
                {
                    throw new AppException("Menu hiện không tồn tại hoặc đã bị xóa");
                }
                _mapper.Map(model, menu);
                _DasContext.Menus.Update(menu);
                _DasContext.SaveChanges();
                return menu;
            }
            catch (Exception e)
            {

                throw new AppException(e.Message);
            }

        }
    }
}
