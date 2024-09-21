using AutoMapper;
using Dulich.Infrastructure;
using Dulich.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Collections.Generic;
using Travel.Application.Enums;
using Travel.Application.InterfaceService;
using Travel.Application.ViewModels;
using Travel.Domain.Interface;
using Travel.Domain.Models;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly ITravelRepositoryWrapper _travelRepo;

        public AccountController(IMapper mapper, IAccountService accountService, ITravelRepositoryWrapper travelRepo)
        {
            _mapper = mapper;
            _travelRepo = travelRepo;
            _accountService = accountService;
        }

        [HttpGet]
        [Route("List-Account")]
        [Authorize]
        public async Task<IActionResult> ListAcount(string? search)
        {
            var result = await _accountService.Search(search);

            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        [Authorize]
        public async Task<IActionResult> Create(Account account)
        {
            var result = await _accountService.Create(account);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetID")]
        [Authorize]
        public async Task<IActionResult> GetID(int id)
        {
            var result = await _accountService.GetID(id);
            
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _accountService.Delete(id);

            return Ok(new { message = result });
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] VMAccount account)
        {

            var result = await _accountService.Edit(account);

            return Ok(result);
        }

    }
}
