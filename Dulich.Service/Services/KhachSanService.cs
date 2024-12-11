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
using Travel.Domain.Interface;

namespace Travel.Application.Services
{
    class KhachSanService :BaseMasterService, IKhachSanService
    {
        private readonly IMapper _mapper;
        private readonly DASContext _DasContext;

        public KhachSanService(ITravelRepositoryWrapper travelRepository, IMapper mapper, DASContext dASContext) : base(travelRepository)
        {
            _mapper = mapper;
            _travelRepo = travelRepository;
            _DasContext = dASContext;

        }

        public async Task<KhachSan> Create(KhachSan khachSan)
        {
            try
            {
                await _DasContext.AddAsync(khachSan);
                await _DasContext.SaveChangesAsync();
                return khachSan;
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
                var khachSan = await _travelRepo.KhachSanRepository.FirstOrDefaultAsync(x => x.ID == id);
                if (khachSan == null) throw new AppException("KhachSan không tồn tại hoặc đã bị xóa");

                _travelRepo.KhachSanRepository.Delete(khachSan);
                _DasContext.SaveChanges();
                return $"Xóa KhachSan: {khachSan.Name} thành công";
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
                var khachSan = await _travelRepo.KhachSanRepository.FirstOrDefaultAsync(x => x.ID == id);
                if (khachSan == null) throw new AppException("KhachSan không tồn tại hoặc đã bị xóa");
                return khachSan;
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
                var khachSan = await (from M in _travelRepo.KhachSanRepository.GetAll().AsNoTracking()
                                  where (string.IsNullOrEmpty(searchMeta) || M.Name.Contains(searchMeta))
                                  orderby M.ID descending
                                  select M).ToListAsync();
                if (!khachSan.Any()) throw new AppException("Không tìm thấy dữ liệu phù hợp");

                return khachSan;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }

        }


        public async Task<VMKhachSan> update(VMKhachSan model)
        {
            try
            {
                var khachSan = await (from m in _travelRepo.KhachSanRepository.GetAll()
                                  where m.ID == model.ID
                                  select m).FirstOrDefaultAsync();
                if (khachSan == null)
                {
                    throw new AppException("KhachSan hiện không tồn tại hoặc đã bị xóa");
                }
                _mapper.Map(khachSan, model);
                _DasContext.KhachSans.Update(khachSan);
                _DasContext.SaveChanges();

                return model;
            }
            catch (Exception e)
            {

                throw new AppException(e.Message);
            }

        }

        public async Task<VMKhachSan> GetById(int id)
        {

            var khachSan = await (from m in _travelRepo.KhachSanRepository.GetAll()
                              where m.ID == id
                              select m).FirstOrDefaultAsync();

            if (khachSan == null)
            {
                throw new AppException("Dữ liệu không tồn tại hoặc đã bị xóa");
            }
            var vmKhachSan = _mapper.Map<VMKhachSan>(khachSan);


            return vmKhachSan;
        }

        //public async Task<List<KhachSan>> GetKhachSanChild(int idParent)
        //{
        //    List<KhachSan> khachSans = new List<KhachSan>();

        //    if (idParent <= 0)
        //        return khachSans;

        //    var khachSanByParent = await (from m in _travelRepo.KhachSanRepository.GetAll()
        //                              where idParent == m.IDParent && m.IsActive == (int)EnumCommon.Status.Active
        //                              select m).ToListAsync();
        //    return khachSanByParent;
        //}
    }
}
