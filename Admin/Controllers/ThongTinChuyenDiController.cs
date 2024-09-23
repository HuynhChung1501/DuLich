using AutoMapper;
using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using Dulich.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Travel.Application.Services;
using Travel.Domain.Interface;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpGet]
        [Route("List")]
        [Authorize]
        public async Task<IActionResult> GetList(string? searchMeta)
        {
            var chuyendi = await _ThongTinChuyenDiService.Search(searchMeta);

            return Ok(chuyendi);

        }
        #endregion

        #region Create
        [HttpPost]
        [Route("Create")]
        [Authorize]
        public async Task<IActionResult> Create(ThongTinChuyenDi thongTinChuyenDi)
        {
            var rs = await _ThongTinChuyenDiService.Create(thongTinChuyenDi);

            return Ok(rs);
        }
        #endregion

        #region Update
        [Authorize]
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(ThongTinChuyenDi thongTinChuyenDi)
        {
            var rs = await _ThongTinChuyenDiService.update(thongTinChuyenDi);

            return Ok(rs);
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await _ThongTinChuyenDiService.Delete(id);
            return Ok(new { message = rs });
        }

        [HttpDelete]
        [Route("Deletes")]
        [Authorize]
        public async Task<IActionResult> Deletes([FromQuery] int[] ids)
        {
            var rs = await _ThongTinChuyenDiService.Deletes(ids);
            return Ok(new { message = rs });
        }
        #endregion
    }
}
