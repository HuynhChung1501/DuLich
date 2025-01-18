
using AutoMapper;
using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using Dulich.Infrastructure;
using Dulich.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Travel.API.Controllers;
using Travel.Application.Enums;
using Travel.Application.ViewModels;
using Travel.Domain.CustomModels;
using Travel.Domain.Interface;
using Travel.Domain.Models;
using Travel.Infrastructure.Migrations;
using X.PagedList.Extensions;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
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

        #region search
        [HttpGet]
        [Route("List")]
        [HasPermission(Permissions = new[] { EnumPermission.Read }, Modules = new[] { EnumModule.Menu })]
        public async Task<IActionResult> Index(string? searchMeta = "")
        {
            var Menus = await _menuServices.Search(searchMeta);

            return Ok(Menus);
        }

        [HttpGet]
        [Route("GetById")]
        [HasPermission(Permissions = new[] { EnumPermission.Read }, Modules = new[] { EnumModule.Menu })]
        public async Task<IActionResult> GetById(int id)
        {
            var menu = await _menuServices.GetById(id);

            return Ok(menu);
        }

        #endregion

        #region Thêm mới menu

        [HttpPost]
        [Route("Create")]
        [HasPermission(Permissions = new[] { EnumPermission.Create }, Modules = new[] { EnumModule.Menu })]
        public async Task<IActionResult> Create(Menu menu)
        {
            var rs = await _menuServices.Create(menu);

            return Ok(rs);
        }
        #endregion

        #region Update
        [HttpPut]
        [Route("Update")]
        [HasPermission(Permissions = new[] { EnumPermission.Update }, Modules = new[] { EnumModule.Menu })]
        public async Task<IActionResult> Update(VMMenu menu)
        {
            var rs = await _menuServices.update(menu);
            return Ok(rs);

        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("Delete")]
        [HasPermission(Permissions = new[] { EnumPermission.Delete }, Modules = new[] { EnumModule.Menu })]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await _menuServices.Delete(id);
            return Ok(rs);
        }

        [HttpDelete]
        [Route("Deletes")]
        [HasPermission(Permissions = new[] { EnumPermission.Delete }, Modules = new[] { EnumModule.Menu })]
        public async Task<IActionResult> Deletes([FromQuery] int[] ids)
        {
            var rs = await _menuServices.Deletes(ids);
            return Ok(new { message = rs });
        }
        #endregion



    }
}
