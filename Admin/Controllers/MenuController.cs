
using AutoMapper;
using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using Dulich.Infrastructure;
using Dulich.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Travel.API.Controllers;
using Travel.Domain.CustomModels;
using Travel.Domain.Interface;
using Travel.Domain.Models;
using X.PagedList.Extensions;

namespace Travel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        [HttpGet]
        [Route("List-Menu")]
        public async Task<IActionResult> Index()
        {
            VMMenu MenuList = new VMMenu();
            MenuList.Menus = await _menuServices.GetList();

            ViewData["page"] = MenuList.Menus.Count();
            return Json(MenuList);

        }
        #endregion

        #region Thêm mới menu
        //[httppost(name = "thêm mới menu")]
        //public async task<iactionresult> create()
        //{
        //    var rs = new vmmenu();
        //    rs.menus = _travelrepo.menu.getalllist().tolist() ?? new list<menu>();
        //    viewdata["title"] = "thêm mới menu";
        //    viewdata["linksubmit"] = "create";
        //    return view("create", rs);
        //}

        [HttpPost]
        [Route("Create-Menu")]
        public async Task<IActionResult> Create(Menu menu)
        {
            var rs = await _menuServices.Create(menu);
            return CustJSonResult(rs);
        }
        #endregion

        #region Update
        //sử dụng khi dựng web
        //public async Task<IActionResult> Update(int id)
        //{
        //    ViewData["Title"] = "Chỉnh sửa menu";
        //    ViewData["linkSubmit"] = "Update";

        //    var rs = await _menuServices.GetVmMenu(id);
        //    if (rs == null)
        //    {
        //        return JSErrorResult("Menu không tồn tại");
        //    }
        //    rs.NameParent = _travelRepo.Menu.FirstOrDefault(x => x.ID == rs.Menu.IDParent)?.Name;

        //    rs.Menus = _travelRepo.Menu.GetAllList().ToList() ?? new List<Menu>();
        //    return View("Update", rs);
        //}

        [HttpPut]
        [Route("Delete")]
        public async Task<IActionResult> Update(Menu menu)
        {
            var rs = await _menuServices.update(menu);
            return CustJSonResult(rs);

        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await _menuServices.Delete(id);
            return CustJSonResult(rs);
        }

        [HttpDelete]
        [Route("Deletes")]
        public async Task<IActionResult> Deletes(int[] ids)
        {
            var rs = await _menuServices.Deletes(ids);
            return CustJSonResult(rs);
        }
        #endregion

        

    }
}
