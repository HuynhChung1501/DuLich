using AutoMapper;
using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using Dulich.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travel.Application.InterfaceService;
using Travel.Application.ViewModels;
using Travel.Domain.Interface;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachSanController : BaseController
    {

        private readonly IMapper _mapper;
        private readonly IKhachSanService _khachSanService;
        private readonly ITravelRepositoryWrapper _travelRepo;

        public KhachSanController(IMapper mapper, IKhachSanService khachSanService, ITravelRepositoryWrapper travelRepo)
        {
            _mapper = mapper;
            _travelRepo = travelRepo;
            _khachSanService = khachSanService;
        }

        #region List
        [HttpGet]
        [Route("List")]
        [Authorize]
        public async Task<IActionResult> index(string? searchMeta)
        {
            var khachSan = await _khachSanService.Search(searchMeta);

            return Ok(khachSan);

        }
        #endregion

        #region Create
        [HttpPost]
        [Route("Create")]
        [Authorize]
        public async Task<IActionResult> Create(KhachSan khachSan)
        {
            var rs = await _khachSanService.Create(khachSan);

            return Ok(rs);
        }
        #endregion

        #region Update
        [Authorize]
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(VMKhachSan khachSan)
        {
            var rs = await _khachSanService.update(khachSan);

            return Ok(rs);
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await _khachSanService.Delete(id);
            return Ok(new { message = rs });
        }

        [HttpDelete]
        [Route("Deletes")]
        [Authorize]
        public async Task<IActionResult> Deletes([FromQuery] int[] ids)
        {
            var rs = await _khachSanService.Deletes(ids);
            return Ok(new { message = rs });
        }
        #endregion

    }
}
