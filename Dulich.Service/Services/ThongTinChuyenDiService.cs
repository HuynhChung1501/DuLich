using AutoMapper;
using Dulich.Application.ViewModels;
using Dulich.Domain.Interface;
using Dulich.Domain.Models;
using Dulich.Infrastructure;
using Dulich.Infrastructure.Migrations;
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

        public async Task<ServiceResult> Create(ThongTinChuyenDi chuyenDi)
        {
            if (chuyenDi == null)
            {
                return new ServiceResultError("Thêm mới không thành công");
            }
            var valid = await validation(chuyenDi);
            if (valid.Code == CommonConst.error)
            {
                return valid;
            }
            _DasContext.Add(chuyenDi);
            _DasContext.SaveChanges();
            return valid;

        }

        public async Task<ServiceResult> Delete(int id)
        {
            try
            {
                var ThongTinChuyenDi = _travelRepo.ThongTinChuyenDi.Get(id);
                if (ThongTinChuyenDi == null)
                {
                    return new ServiceResultError("Chuyến đi không tồn tại hoặc đã bị xóa");
                }

                _travelRepo.ThongTinChuyenDi.Delete(ThongTinChuyenDi);
                _DasContext.SaveChanges();
                return new ServiceResultSuccess("Xóa Chuyến đi thành công");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ServiceResult> Deletes(int[] ids)
        {
            try
            {
                if (ids.Length == 0)
                {
                    return new ServiceResultError($"Không có phần tử nào được xóa");

                }
                foreach (var id in ids)
                {
                    var rs = await Delete(id);
                    if (rs.Code == CommonConst.error)
                    {
                        return new ServiceResultError($"ID: {id} không tồn tại");

                    }
                }
                return new ServiceResultSuccess("Xóa thành công");

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ThongTinChuyenDi> Get(int id)
        {
            var rs = await _travelRepo.ThongTinChuyenDi.FirstOrDefaultAsync(x => x.ID == id);
            return rs;
        }

        public async Task<List<ThongTinChuyenDi>> GetList()
        {
            var chuyenDi = await (from M in _travelRepo.ThongTinChuyenDi.GetAll().AsNoTracking()
                                    orderby M.ID descending
                                    select M).ToListAsync();
            return chuyenDi;
        }

        public async Task<List<VMThongTinChuyenDi>> SearchByCondition(string searchName)
        {
            var chuyenDi = await (from M in _travelRepo.ThongTinChuyenDi.GetAll().AsNoTracking()
                                    where searchName != null ? searchName.ToLower() == M.Name.ToLower() : true
                                    select new VMThongTinChuyenDi
                                    {
                                        Name = M.Name,
                                        ID = M.ID,
                                    }).ToListAsync();
            return chuyenDi;
        }
        public async Task<VMThongTinChuyenDi> GetVmThongTinPhuongTien(int id)
        {
            var chuyenDi = _travelRepo.ThongTinChuyenDi.FirstOrDefault(x => x.ID == id);
            var vmChuyenDi = new VMThongTinChuyenDi();
            vmChuyenDi.thongTinChuyenDi = chuyenDi;

            return vmChuyenDi;
        }

        public async Task<ServiceResult> update(ThongTinChuyenDi chuyenDi)
        {
            var phuongTienOld = (from m in _travelRepo.ThongTinChuyenDi.GetAll()
                                where m.ID == chuyenDi.ID
                                select new ThongTinChuyenDi
                                {
                                    Name = chuyenDi.Name,
                                    ID = chuyenDi.ID,
                                    StartDate = chuyenDi.StartDate,
                                    PickupLocation = chuyenDi.PickupLocation,
                                    IDTransport = chuyenDi.IDTransport,
                                    Description = chuyenDi.Description,
                                    IDTour = chuyenDi.IDTour,
                                }).FirstOrDefault();
                           ;

            if (phuongTienOld == null)
            {
                return new ServiceResultError("Chuyến đi hiện không tồn tại hoặc đã bị xóa");
            }
            var valid = await validation(chuyenDi);
            if (valid.Code == CommonConst.error)
            {
                return valid;
            }
            await _travelRepo.ThongTinChuyenDi.UpdateAsync(phuongTienOld);
            _DasContext.SaveChanges();
            return new ServiceResultSuccess("Chỉnh sửa thành công");
        }

        public async Task<ServiceResult> validation(ThongTinChuyenDi chuyenDi)
        {
            var checkName = (from m in _travelRepo.ThongTinChuyenDi.GetAll().AsNoTracking()
                             where m.Name == chuyenDi.Name
                             select m).ToList();
            if (checkName.Count() > 0)
            {
                return new ServiceResultError($"{chuyenDi.Name} đã tồn tại");

            }
            if (chuyenDi.Name == string.Empty || chuyenDi.Name == null)
            {
                return new ServiceResultError("Tên không được bỏ trống");
            }

            return new ServiceResultSuccess("Thêm mới thành công");
        }
    }
}
