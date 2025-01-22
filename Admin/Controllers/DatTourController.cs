using AutoMapper;
using Dulich.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travel.Application.ViewModels;
using Travel.Domain.Interface;
using Travel.Domain.Models;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [HasPermission(Permissions = "Admin")]
    public class DatTourController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDatTourServices _datTourServices;
        private readonly ITravelRepositoryWrapper _travelRepo;

        public DatTourController(IMapper mapper, IDatTourServices datTourServicesService, ITravelRepositoryWrapper travelRepo)
        {
            _mapper = mapper;
            _travelRepo = travelRepo;
            _datTourServices = datTourServicesService;
        }

        #region List
        [HttpGet]
        [Route("List")]
        [Authorize]
        public async Task<IActionResult> GetList(string? searchMeta)
        {
            var tour = await _datTourServices.Search(searchMeta);

            return Ok(tour);

        }
        #endregion

        #region Create
        [HttpPost]
        [Route("Create")]
        [Authorize]
        public async Task<IActionResult> Create(DatTour tour)
        {
            var rs = await _datTourServices.Create(tour);

            return Ok(rs);
        }
        #endregion

        #region Update
        [Authorize]
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(DatTour tour)
        {
            var rs = await _datTourServices.Update(tour);

            return Ok(rs);
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateTrangThai")]
        public async Task<IActionResult> UpdateTrangThai(int id, int trangThai)
        {
            var rs = await _datTourServices.UpdateTrangThai(id, trangThai);
            return Ok(rs);
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await _datTourServices.Delete(id);
            return Ok(new { message = rs });
        }

        [HttpDelete]
        [Route("Deletes")]
        [Authorize]
        public async Task<IActionResult> Deletes([FromQuery] int[] ids)
        {
            var rs = await _datTourServices.Deletes(ids);
            return Ok(new { message = rs });
        }
        #endregion


    }
}
