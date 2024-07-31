
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
            ViewData["Title"] = "Thêm mới menu";
            ViewData["linkSubmit"] = "Create";
            return View("Create");
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
            if (rs)
            {
                return JSSuccessResult("Thêm mới thành công");

            }
            return JSWarningResult("Thêm mới không thành công");
        }

        public async Task<IActionResult> Deletes(int[] ids)
        {
            var rs = await _menuServices.Deletes(ids);
            if (rs)
            {
                return JSSuccessResult("Thêm mới thành công");

            }
            return JSWarningResult("Thêm mới không thành công");
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int id)
        {
            ViewData["Title"] = "Chỉnh menu";
            ViewData["linkSubmit"] = "Update";
            var rs = _menuServices.Get(id);
            if (rs == null)
            {
                return JSErrorResult("Menu không tồn tại");
            }
            return View("Create", rs);
        }

        [HttpPost]
        public async Task<IActionResult> Update(VMMenu vmmenu)
        {
            var value = new Menu();
            var rs = await _menuServices.update(vmmenu);
            if (!rs)
            {
                return JSErrorResult("Cập nhật Menu không thành công!");

            }
            return JSSuccessResult("Cập nhật thành công!");

        }
        #endregion

    }
}
