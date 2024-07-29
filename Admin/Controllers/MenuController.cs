
using AutoMapper;
using Dulich.Domain.Models;
using Dulich.Infrastructure;
using Dulich.Service.Interface;
using Dulich.Service.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Travel.Domain.Interface;

namespace Admin.Controllers
{
    public class MenuController :  Controller
    {
        private readonly IMapper _mapper;
        private readonly IMenuServices _menuServices;
        private readonly ITravelRepositoryWrapper _travelRepo;

        public MenuController(IMapper mapper, IMenuServices menuServices, ITravelRepositoryWrapper travelRepo)
        {
            _mapper = mapper;
            _travelRepo = travelRepo;
            _menuServices = menuServices;
        }

        #region search
        public async Task<IActionResult> Index()
        {
            List<Menu> MenuList = new List<Menu>();
            MenuList = await _menuServices.GetList();
            if (MenuList != null)
            {
                return View(MenuList);

            }
            return View(MenuList);

        }
        #endregion

        #region Thêm mới menu
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Menu menu)
        {
            var rs = _mapper.Map<Menu>(menu);
            return View(menu);
        }
        #endregion

    }
}
