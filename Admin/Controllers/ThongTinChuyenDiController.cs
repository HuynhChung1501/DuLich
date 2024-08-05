﻿using AutoMapper;
using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using Dulich.Infrastructure.Migrations;
using Dulich.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Travel.Application.Services;
using Travel.Domain.Interface;

namespace Travel.API.Controllers
{
    public class ThongTinChuyenDiController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IThongTinChuyenDiService _ThongTinChuyenDiService;
        private readonly ITravelRepositoryWrapper _travelRepo;

        public ThongTinChuyenDiController(IMapper mapper, IThongTinChuyenDiService thongTinDiChuyenService, ITravelRepositoryWrapper travelRepo)
        {
            _mapper = mapper;
            _travelRepo = travelRepo;
            _ThongTinChuyenDiService = thongTinDiChuyenService;
        }

        #region List
        public async Task<IActionResult> Index()
        {
            VMThongTinChuyenDi thongTinDiChuyen = new VMThongTinChuyenDi();
            thongTinDiChuyen.ThongTinChuyenDis = await _ThongTinChuyenDiService.GetList();

            ViewData["page"] = thongTinDiChuyen.ThongTinChuyenDis.Count();
            return Json(thongTinDiChuyen.ThongTinChuyenDis);

        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ThongTinChuyenDi thongTinChuyenDi)
        {
            var rs = await _ThongTinChuyenDiService.Create(thongTinChuyenDi);

            return CustJSonResult(rs);
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int id)
        {
            var vm = new VMThongTinChuyenDi();
            vm.thongTinChuyenDi = await _ThongTinChuyenDiService.Get(id);
            if (vm.thongTinChuyenDi == null)
            {
                return JSErrorResult("Chuyến đi không tồn tại hoặc đã bị xóa");
            }
            return View("Update", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ThongTinChuyenDi thongTinChuyenDi)
        {
            var rs = await _ThongTinChuyenDiService.update(thongTinChuyenDi);

            return CustJSonResult(rs);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await _ThongTinChuyenDiService.Delete(id);
            return CustJSonResult(rs);
        }

        [HttpDelete]
        public async Task<IActionResult> Deletes(int[] ids)
        {
            var rs = await _ThongTinChuyenDiService.Deletes(ids);
            return CustJSonResult(rs);
        }
        #endregion
    }
}