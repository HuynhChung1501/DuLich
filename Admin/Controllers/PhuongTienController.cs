using AutoMapper;
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
    public class PhuongTienController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IPhuongTienService _PhuongTienService;
        private readonly ITravelRepositoryWrapper _travelRepo;

        public PhuongTienController(IMapper mapper, IPhuongTienService thongTienPhuongTien, ITravelRepositoryWrapper travelRepo)
        {
            _mapper = mapper;
            _travelRepo = travelRepo;
            _PhuongTienService = thongTienPhuongTien;
        }

        #region List
        public async Task<IActionResult> Index()
        {
            VMPhuongTien phuongTien = new VMPhuongTien();
            phuongTien.PhuongTiens = await _PhuongTienService.GetList();

            ViewData["page"] = phuongTien.PhuongTiens.Count();
            return Json(phuongTien.PhuongTiens);

        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PhuongTien PhuongTien)
        {
            var rs = await _PhuongTienService.Create(PhuongTien);

            return CustJSonResult(rs);
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int id)
        {
            var vm = new VMPhuongTien();
            vm.PhuongTien = await _PhuongTienService.Get(id);
            if (vm.PhuongTien == null)
            {
                return JSErrorResult("Phương tiện không tồn tại hoặc đã bị xóa");
            }
            return View("Update", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PhuongTien PhuongTien)
        {
            var rs = await _PhuongTienService.update(PhuongTien);

            return CustJSonResult(rs);
        }
        #endregion


        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await _PhuongTienService.Delete(id);
            return CustJSonResult(rs);
        }

        public async Task<IActionResult> Deletes(int[] ids)
        {
            var rs = await _PhuongTienService.Deletes(ids);
            return CustJSonResult(rs);
        }
        #endregion
    }
}
