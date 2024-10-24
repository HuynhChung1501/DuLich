using AutoMapper;
using Dulich.Domain.Models;
using Dulich.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travel.Application.Services;
using Travel.Application.ViewModels;
using Travel.Domain.Interface;
using Travel.Domain.Models;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ITourServicesService _tourServicesService;
        private readonly ITravelRepositoryWrapper _travelRepo;

        public TourController(IMapper mapper, ITourServicesService tourServicesService, ITravelRepositoryWrapper travelRepo)
        {
            _mapper = mapper;
            _travelRepo = travelRepo;
            _tourServicesService = tourServicesService;
        }

        #region List
        [HttpGet]
        [Route("List")]
        [Authorize]
        public async Task<IActionResult> GetList(string? searchMeta)
        {
            var tour = await _tourServicesService.Search(searchMeta);

            return Ok(tour);

        }
        #endregion

        #region Create
        [HttpPost]
        [Route("Create")]
        [Authorize]
        public async Task<IActionResult> Create(Tour tour)
        {
            var rs = await _tourServicesService.Create(tour);

            return Ok(rs);
        }
        #endregion

        #region Update
        [Authorize]
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(VMTour tour)
        {
            var rs = await _tourServicesService.update(tour);

            return Ok(rs);
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await _tourServicesService.Delete(id);
            return Ok(new { message = rs });
        }

        [HttpDelete]
        [Route("Deletes")]
        [Authorize]
        public async Task<IActionResult> Deletes([FromQuery] int[] ids)
        {
            var rs = await _tourServicesService.Deletes(ids);
            return Ok(new { message = rs });
        }
        #endregion

    }
}
