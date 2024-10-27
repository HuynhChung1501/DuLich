using AutoMapper;
using Dulich.Domain.Models;
using Dulich.Infrastructure;
using Dulich.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.Enums;
using Travel.Application.Helpers;
using Travel.Application.ViewModels;
using Travel.Domain.Interface;
using Travel.Domain.Models;
using Travel.Infrastructure.Migrations;

namespace Travel.Application.Services
{
    public class DatTourService : BaseMasterService, IDatTourServices
    {
        private readonly IMapper _mapper;
        private readonly DASContext _DasContext;

        public DatTourService(ITravelRepositoryWrapper travelRepository, IMapper mapper, DASContext dASContext) : base(travelRepository)
        {
            _mapper = mapper;
            _travelRepo = travelRepository;
            _DasContext = dASContext;

        }

        public async Task<DatTour> Create(DatTour tour)
        {
            try
            {
                await _DasContext.AddAsync(tour);
                await _DasContext.SaveChangesAsync();
                return tour;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                var tour = await _travelRepo.DatTourRepository.FirstOrDefaultAsync(x => x.ID == id);
                if (tour == null) throw new AppException("Đặt Tour không tồn tại hoặc đã bị xóa");

                _travelRepo.DatTourRepository.Delete(tour);
                _DasContext.SaveChanges();
                return $"Xóa đặt Tour thành công";
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public async Task<string> Deletes(int[] ids)
        {
            try
            {
                if (ids.Length == 0)
                {
                    throw new AppException($"Không có phần tử nào được xóa");
                }
                foreach (var id in ids)
                {
                    var rs = await Delete(id);
                }
                return ("Xóa thành công");

            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
        }

        public async Task<string> UpdateTrangThai(int idDatTour, int trangThai)
        {
            try
            {
                var datTour = await _DasContext.DatTour.FirstOrDefaultAsync(x => x.ID == idDatTour);
                if(Enum.IsDefined(typeof(DatTourEnum.TinhTrang), trangThai))
                {
                    if (datTour != null)
                    {
                        datTour.TinhTrang = trangThai;
                    }
                    else
                    {
                        throw new AppException("Dữ liệu không tồn tại hoặc đã bị xóa");
                    }
                } else
                {
                    throw new AppException("Trạng thái không phù hợp");
                }
                _DasContext.DatTour.Update(datTour);
                _DasContext.SaveChanges();
                return ("Update trạng thái thanh toán thành công");

            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
        }



        public async Task<DatTour> Get(int id)
        {
            try
            {
                var tour = await _travelRepo.DatTourRepository.FirstOrDefaultAsync(x => x.ID == id);
                if (tour == null) throw new AppException("Dữ liệu không tồn tại hoặc đã bị xóa");
                return tour;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }

        }

        public async Task<List<DatTour>> Search(string? searchMeta)
        {
            try
            {
                var tour = await (from M in _travelRepo.DatTourRepository.GetAll().AsNoTracking()
                                  where (string.IsNullOrEmpty(searchMeta) || M.Hoten.Contains(searchMeta))
                                  orderby M.ID descending
                                  select M).ToListAsync();
                if (!tour.Any()) throw new AppException("Không tìm thấy dữ liệu phù hợp");

                return tour;
            }
            catch (Exception e)
            {

                throw new AppException(e.Message);
            }

        }

        public async Task<DatTour> Update(DatTour model)
        {
            try
            {
                var tour = await (from m in _travelRepo.DatTourRepository.GetAll()
                                  where m.ID == model.ID
                                  select m).FirstOrDefaultAsync();
                if (tour == null)
                {
                    throw new AppException("Đặt tour hiện không tồn tại hoặc đã bị xóa");
                }
                _mapper.Map(model, tour);
                _DasContext.DatTour.Update(tour);
                _DasContext.SaveChanges();
                return tour;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }

        }
    }
}
