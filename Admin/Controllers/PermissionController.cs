using AutoMapper;
using Dulich.Service.Interface;
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
    public class PermissionController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IPermissionService _PermissionService;
        private readonly ITravelRepositoryWrapper _travelRepo;

        public PermissionController(IMapper mapper, IPermissionService permissionService, ITravelRepositoryWrapper travelRepo)
        {
            _mapper = mapper;
            _travelRepo = travelRepo;
            _PermissionService = permissionService;
        }

        #region List
        [HttpGet]
        [Route("List")]
        [Authorize]
        public async Task<IActionResult> GetList(string? searchMeta)
        {
            var permission = await _PermissionService.Search(searchMeta);
            return Ok(permission);
        }
        #endregion

        #region GET
        [HttpGet]
        [Route("GetID")]
        [Authorize]
        public async Task<IActionResult> GetID(int id)
        {
            var permission = await _PermissionService.GetByid(id);
            return Ok(permission);
        }
        #endregion

        #region Create
        [HttpPost]
        [Route("Create")]
        [Authorize]
        public async Task<IActionResult> Create([FromHeader] Permission permission)
        {
            var rs = await _PermissionService.Create(permission);

            return Ok(rs);
        }
        #endregion

        #region Update

        [HttpPut]
        [Authorize]
        [Route("Update")]
        public async Task<IActionResult> Update([FromHeader] Permission permission)
        {
            var rs = await _PermissionService.update(permission);

            return Ok(rs);
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Authorize]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await _PermissionService.Delete(id);
            return Ok(new { message = rs });
        }

        [HttpDelete]
        [Authorize]
        [Route("Deletes")]
        public async Task<IActionResult> Deletes([FromQuery] int[] ids)
        {
            var rs = await _PermissionService.Deletes(ids);
            return Ok(new { message = rs });
        }
        #endregion
    }
}
