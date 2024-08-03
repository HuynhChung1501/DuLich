
using AutoMapper;
using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using Dulich.Infrastructure;
using Dulich.Service.Interface;
using Dulich.Service.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Travel.API.Controllers;
using Travel.Domain.CustomModels;
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
        public async Task<IActionResult> Index()
        {
            VMMenu MenuList = new VMMenu();
            MenuList.Menus = await _menuServices.GetList();

            ViewData["page"] = MenuList.Menus.Count();
            return View("index", MenuList);

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
            var rs =  new VMMenu();
            rs.Menus = _travelRepo.Menu.GetAllList().ToList() ?? new List<Menu>(); 
            ViewData["Title"] = "Thêm mới menu";
            ViewData["linkSubmit"] = "Create";
            return View("Create", rs);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Menu menu)
        {

            var rs = await _menuServices.Create(menu);

            return CustJSonResult(rs);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int id) 
        {
            var rs = await _menuServices.Delete(id);
            return CustJSonResult(rs);
        }

        public async Task<IActionResult> Deletes([FromBody] int[] ids)
        {
            var rs = await _menuServices.Deletes(ids);
            return CustJSonResult(rs);
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int id)
        {
            ViewData["Title"] = "Chỉnh sửa menu";
            ViewData["linkSubmit"] = "Update";

            var rs = await _menuServices.GetVmMenu(id);
            if (rs == null)
            {
                return JSErrorResult("Menu không tồn tại");
            }
            rs.NameParent = _travelRepo.Menu.FirstOrDefault(x=>x.ID == rs.Menu.IDParent)?.Name;

            rs.Menus = _travelRepo.Menu.GetAllList().ToList() ?? new List<Menu>();
            return View("Update", rs);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] Menu menu)
        {
            var rs = await _menuServices.update(menu);
            return CustJSonResult(rs);

        }
        #endregion

    }
}
