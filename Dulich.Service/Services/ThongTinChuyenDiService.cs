using AutoMapper;
using Dulich.Application.ViewModels;
using Dulich.Domain.Interface;
using Dulich.Domain.Models;
using Dulich.Infrastructure;
using Dulich.Service.Interface;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Abstractions.Internal;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Travel.Application.Services
{
    public class ThongTinChuyenDiService : BaseMasterService, IThongTinChuyenDiService
    {
        private readonly IMapper _mapper;
        private readonly DASContext _DasContext;

        public ThongTinChuyenDiService(ITravelRepositoryWrapper travelRepository, IMapper mapper, DASContext dASContext) : base(travelRepository)
        {
            _mapper = mapper;
            _travelRepo = travelRepository;
            _DasContext = dASContext;

        }

        public async Task<ThongTinChuyenDi> Create(ThongTinChuyenDi chuyenDi)
        {
           await _DasContext.AddAsync(chuyenDi);
           await _DasContext.SaveChangesAsync();
            return chuyenDi;

        }

        public async Task<string> Delete(int id)
        {
            try
            {
                var ThongTinChuyenDi = _travelRepo.ThongTinChuyenDi.Get(id);
                if (ThongTinChuyenDi == null)
                {
                    throw new AppException($"Chuyến đi không tồn tại hoặc đã bị xóa");
                }

                _travelRepo.ThongTinChuyenDi.Delete(ThongTinChuyenDi);
                _DasContext.SaveChanges();
                return "Xóa Chuyến đi thành công";
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
        }

        public async Task<string> Deletes(int[] ids)
        {
            if (ids.Length == 0)
            {
                throw new AppException("Chuyến đi không tồn tại hoặc đã bị xóa");
            }
            foreach (var id in ids)
            {
                var rs = await Delete(id);
            }
            return "Xóa thành công";
        }

        public async Task<ThongTinChuyenDi> Get(int id)
        {
            var rs = await _travelRepo.ThongTinChuyenDi.FirstOrDefaultAsync(x => x.ID == id);
            return rs;
        }

        public async Task<List<ThongTinChuyenDi>> Search(string? searchMeta)
        {
            var chuyenDi = await (from M in _travelRepo.ThongTinChuyenDi.GetAll().AsNoTracking()
                                    orderby M.ID descending
                                    select M).ToListAsync();
            if (!chuyenDi.Any()) throw new KeyNotFoundException("Không tìm thấy dữ liệu phù hợp");

            return chuyenDi;
        }

        public async Task<ThongTinChuyenDi> update(ThongTinChuyenDi model)
        {
            try
            {
                var chuyenDi = await (from m in _travelRepo.ThongTinChuyenDi.GetAll()
                                        where m.ID == model.ID 
                                        select m).FirstOrDefaultAsync();

                if (chuyenDi == null)
                {
                    throw new AppException("Chuyến đi hiện không tồn tại hoặc đã bị xóa");
                }
                 _mapper.Map(model, chuyenDi);
                _DasContext.ThongTinChuyenDis.Update(chuyenDi);
                await _DasContext.SaveChangesAsync();
                return chuyenDi;
            }
            catch (Exception e)
            {

                throw new AppException(e.Message);
            }
        }
    }
}
