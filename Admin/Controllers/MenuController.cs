
using AutoMapper;
using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using Dulich.Infrastructure;
using Dulich.Service.Interface;
using Dulich.Service.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Travel.API.Controllers;
using Travel.Domain.Interface;
using Travel.Domain.Models;
using X.PagedList.Extensions;

namespace Admin.Controllers
{
    public class MenuController :  BaseController
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

        #region List
        public async Task<IActionResult> Index(int page, int pagesize)
        {
            List<VMMenu> MenuList = new List<VMMenu>();
            MenuList = await _menuServices.GetList();

            int pageSize = pagesize == 0  ? 5 : pagesize;
            int pageNumber = page == 0 ? 1 : page;
            ViewData["page"] = MenuList.Count();
            return View(MenuList.ToPagedList(pageNumber, pageSize));

        }

        public async Task<IActionResult> SearchByCondition(string searchName)
        {
            List<VMMenu> MenuList = new List<VMMenu>();
            MenuList = await _menuServices.SearchByCondition(searchName);
            if (MenuList != null)
            {
                return Json(MenuList);
            }
            return Json(MenuList);
        }
        #endregion

        #region Thêm mới menu
        public async Task<IActionResult> Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Menu menu)
        {
            var data = new JsonData();
            if (menu != null) {
                return JSWarningResult("Thêm mới thành công");
            }
            return JSSuccessResult("Thêm mới không thành công");
        }
        #endregion

    }
}
