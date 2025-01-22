using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travel.Application.InterfaceService;
using Travel.Domain.Interface;
using Travel.Domain.Models;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [HasPermission(Permissions = "Admin")]
    public class PhanQuyenController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPhanQuyenService _PhanQuyenService;
        private readonly ITravelRepositoryWrapper _travelRepo;

        public PhanQuyenController(IMapper mapper, IPhanQuyenService PhanQuyenService, ITravelRepositoryWrapper travelRepo)
        {
            _mapper = mapper;
            _travelRepo = travelRepo;
            _PhanQuyenService = PhanQuyenService;
        }

        #region List
        [HttpGet]
        [Route("List")]
        [Authorize]
        public async Task<IActionResult> GetList(string? searchMeta)
        {
            var phanQuyen = await _PhanQuyenService.Search(searchMeta);
            return Ok(phanQuyen);
        }
        #endregion

        #region GET
        [HttpGet]
        [Route("GetID")]
        [Authorize]
        public async Task<IActionResult> GetID(int id)
        {
            var phanQuyen = await _PhanQuyenService.GetById (id);
            return Ok(phanQuyen);
        }
        #endregion

        #region Create
        [HttpPost]
        [Route("Create")]
        [Authorize]
        public async Task<IActionResult> Create([FromHeader] PhanQuyen phanQuyen)
        {
            var rs = await _PhanQuyenService.Create(phanQuyen);

            return Ok(rs);
        }
        #endregion

        #region Update

        [HttpPut]
        [Authorize]
        [Route("Update")]
        public async Task<IActionResult> Update([FromHeader] PhanQuyen phanQuyen)
        {
            var rs = await _PhanQuyenService.update(phanQuyen);

            return Ok(rs);
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Authorize]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await _PhanQuyenService.Delete(id);
            return Ok(new { message = rs });
        }

        [HttpDelete]
        [Authorize]
        [Route("Deletes")]
        public async Task<IActionResult> Deletes([FromQuery] int[] ids)
        {
            var rs = await _PhanQuyenService.Deletes(ids);
            return Ok(new { message = rs });
        }
        #endregion
    }
}
