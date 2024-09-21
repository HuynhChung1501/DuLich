using AutoMapper;
using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using Dulich.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travel.Domain.Interface;
using Travel.Domain.Models;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinPhuongTienController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IThongTinPhuongTienService _PhuongTienService;
        private readonly ITravelRepositoryWrapper _travelRepo;

        public ThongTinPhuongTienController(IMapper mapper, IThongTinPhuongTienService thongTienPhuongTien, ITravelRepositoryWrapper travelRepo)
        {
            _mapper = mapper;
            _travelRepo = travelRepo;
            _PhuongTienService = thongTienPhuongTien;
        }

        #region List
        [HttpGet]
        [Route("List-ThongTinPhuongTien")]
        [Authorize]
        public async Task<IActionResult> GetList(string? searchMeta)
        {
            var phuongTien = await _PhuongTienService.Search(searchMeta);
            return Ok(phuongTien);
        }
        #endregion

        #region GET
        [HttpGet]
        [Route("GetID")]
        [Authorize]
        public async Task<IActionResult> GetID(int id)
        {
            var phuongTien = await _PhuongTienService.Get(id);
            return Ok(phuongTien);
        }
        #endregion

        #region Create
        [HttpPost]
        [Route("Create-ThongTinPhuongTien")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody]ThongTinPhuongTien PhuongTien)
        {
            var rs = await _PhuongTienService.Create(PhuongTien);

            return Ok(rs);
        }
        #endregion

        #region Update
        //sử dụng khi nào dụng web
        //public async Task<IActionResult> Update(int id)
        //{
        //    var vm = new VMPhuongTien();
        //    vm.PhuongTien = await _PhuongTienService.Get(id);
        //    if (vm.PhuongTien == null)
        //    {
        //        return JSErrorResult("Phương tiện không tồn tại hoặc đã bị xóa");
        //    }
        //    return View("Update", vm);
        //}

        [HttpPut]
        [Authorize]
        [Route("Update-PhuongTien")]
        public async Task<IActionResult> Update(ThongTinPhuongTien PhuongTien)
        {
            var rs = await _PhuongTienService.update(PhuongTien);

            return Ok(rs);
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Authorize]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await _PhuongTienService.Delete(id);
            return Ok(new { message = rs });
        }

        [HttpDelete]
        [Authorize]
        [Route("Deletes")]
        public async Task<IActionResult> Deletes(int[] ids)
        {
            var rs = await _PhuongTienService.Deletes(ids);
            return Ok(new { message = rs });
        }
        #endregion
    }
}
