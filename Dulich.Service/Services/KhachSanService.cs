using AutoMapper;
using Dulich.Application.ViewModels;
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
using Travel.Application.InterfaceService;
using Travel.Application.ViewModels;
using Travel.Domain.Interface;
using Travel.Utility;

namespace Travel.Application.Services
{
    public class KhachSanService : BaseMasterService, IKhachSanService
    {
        private readonly IMapper _mapper;
        private readonly DASContext _DasContext;

        public KhachSanService(ITravelRepositoryWrapper travelRepository, IMapper mapper, DASContext dASContext) : base(travelRepository)
        {
            _mapper = mapper;
            _travelRepo = travelRepository;
            _DasContext = dASContext;

        }

        public async Task<KhachSan> Create(KhachSan tour)
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
                var tour = await _travelRepo.KhachSanRepository.FirstOrDefaultAsync(x => x.ID == id);
                if (tour == null) throw new AppException("Thông tin không tồn tại hoặc đã bị xóa");

                _travelRepo.KhachSanRepository.Delete(tour);
                _DasContext.SaveChanges();
                return $"Xóa khách sạn: {tour.Name} thành công";
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

        public async Task<KhachSan> Get(int id)
        {
            try
            {
                var tour = await _travelRepo.KhachSanRepository.FirstOrDefaultAsync(x => x.ID == id);
                if (tour == null) throw new AppException("Thông tin không tồn tại hoặc đã bị xóa");
                return tour;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }

        }

        public async Task<List<KhachSan>> Search(string? searchMeta)
        {
            try
            {
                var tour = await (from M in _travelRepo.KhachSanRepository.GetAll().AsNoTracking()
                                  where (string.IsNullOrEmpty(searchMeta) || M.Name.Contains(searchMeta))
                                  && M.Active == (int)EnumCommon.Status.Active
                                  orderby M.ID descending
                                  select M).ToListAsync();
                if (Utils.IsNotEmpty(tour)) throw new AppException("Không tìm thấy dữ liệu phù hợp");





                return tour;
            }
            catch (Exception e)
            {

                throw new AppException(e.Message);
            }

        }

        public async Task<KhachSan> update(VMKhachSan model)
        {
            try
            {
                var tour = await (from m in _travelRepo.KhachSanRepository.GetAll()
                                  where m.ID == model.ID
                                  select m).FirstOrDefaultAsync();
                if (tour == null)
                {
                    throw new AppException("Thông tin hiện không tồn tại hoặc đã bị xóa");
                }
                _mapper.Map(model, tour);
                _DasContext.KhachSans.Update(tour);
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
