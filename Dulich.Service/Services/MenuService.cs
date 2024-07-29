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

        public async Task<List<Menu>> GetList()
        {
            var menu = await _travelRepo.Menu.GetAll().AsNoTracking().ToListAsync();
            return menu;
        }
    }
}
