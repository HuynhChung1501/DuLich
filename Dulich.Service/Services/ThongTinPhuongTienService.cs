using AutoMapper;
using Dulich.Application.ViewModels;
using Dulich.Domain.Interface;
using Dulich.Domain.Models;
using Dulich.Infrastructure;
using Dulich.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.Contansts;
using Travel.Application.Enums;
using Travel.Application.Helpers;
using Travel.Domain.CustomModels;
using Travel.Domain.Interface;
using Travel.Domain.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Travel.Application.Services
{
    public class ThongTinPhuongTienService : BaseMasterService, IThongTinPhuongTienService
    {
        private readonly IMapper _mapper;
        private readonly DASContext _DasContext;

        public ThongTinPhuongTienService(ITravelRepositoryWrapper travelRepository, IMapper mapper, DASContext dASContext) : base(travelRepository)
        {
            _mapper = mapper;
            _travelRepo = travelRepository;
            _DasContext = dASContext;

        }

        public async Task<ThongTinPhuongTien> Create(ThongTinPhuongTien phuongTien)
        {
            try
            {
                 await _DasContext.AddAsync(phuongTien);
                 await _DasContext.SaveChangesAsync();
                return phuongTien;
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
                var PhuongTien = await _travelRepo.ThongTinPhuongTien.FirstOrDefaultAsync(x => x.ID == id);
                if (PhuongTien == null) throw new AppException("Phương tiện không tồn tại hoặc đã bị xóa");

                _travelRepo.ThongTinPhuongTien.Delete(PhuongTien);
                _DasContext.SaveChanges();
                return $"Xóa Phương Tiện: {PhuongTien.Ten} thành công";
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

        public async Task<ThongTinPhuongTien> Get(int id)
        {
            try
            {
                var phuongTien = await _travelRepo.ThongTinPhuongTien.FirstOrDefaultAsync(x => x.ID == id);
                if (phuongTien == null) throw new AppException("Phương tiện không tồn tại hoặc đã bị xóa");
                return phuongTien;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }

        }

        public async Task<List<ThongTinPhuongTien>> Search(string? searchMeta)
        {
            try
            {
                var phuongTien = await (from M in _travelRepo.ThongTinPhuongTien.GetAll().AsNoTracking()
                                 where (string.IsNullOrEmpty(searchMeta) || M.Ten.Contains(searchMeta))
                                 && M.IsActive == (int)EnumCommon.Status.Active
                                 orderby M.ID descending
                                 select M).ToListAsync();
                if(!phuongTien.Any()) throw new AppException("Không tìm thấy dữ liệu phù hợp");

                return phuongTien;
            }
            catch (Exception e)
            {

                throw new AppException(e.Message);
            }
           
        }

        public async Task<ThongTinPhuongTien> update(ThongTinPhuongTien model)
        {
            try
            {
                var phuongTien = await (from m in _travelRepo.ThongTinPhuongTien.GetAll()
                                        where m.ID == model.ID && m.IsActive == (int)EnumCommon.Status.Active
                                        select m).FirstOrDefaultAsync();

                if (phuongTien == null)
                {
                    throw new AppException("Phương tiện hiện không tồn tại hoặc đã bị xóa");
                }
                _mapper.Map(model, phuongTien);
                _DasContext.ThongTinPhuongTien.Update(phuongTien);
                _DasContext.SaveChanges();
                return phuongTien;
            }
            catch (Exception e)
            {

                throw new AppException(e.Message);
            }

        }
    }
}
