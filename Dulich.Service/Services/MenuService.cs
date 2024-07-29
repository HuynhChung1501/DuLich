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
using Travel.Application.Services;
using Travel.Domain.Interface;

namespace Dulich.Service.Service
{
    public class MenuService : BaseMasterService,IMenuServices
    {
        private readonly IMapper _mapper;
        private readonly ITravelRepositoryWrapper _travelRepo;

        public MenuService(ITravelRepositoryWrapper travelRepository, IMapper mapper, DASContext dASContext) : base(travelRepository)
        {
            _mapper = mapper;
            _travelRepo = travelRepository;
        }

        public async Task<Menu> Get(int id)
        {
            return await _travelRepo.Menu.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<VMMenu>> GetList()
        {
            var menu = await (from M in _travelRepo.Menu.GetAll().AsNoTracking()
                              select new VMMenu
                              {
                                  Name = M.Name,
                                  ID = M.ID,
                                  Url = M.Url,
                                  Icon = M.Icon,
                                  IDParent = M.IDParent,
                                  CreatedBy = M.CreatedBy,
                                  CreatedDate = M.CreatedDate,
                                  UpdatedBy = M.UpdatedBy,
                                  UpdatedDate = M.UpdatedDate,
                              }).ToListAsync();
            return menu;
        }

        public async Task<List<VMMenu>> SearchByCondition(string searchName)
        {
            var menu = await(from M in _travelRepo.Menu.GetAll().AsNoTracking()
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
    }
}
