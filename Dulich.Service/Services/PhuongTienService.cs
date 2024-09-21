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
using Travel.Domain.CustomModels;
using Travel.Domain.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Travel.Application.Services
{
    public class PhuongTienService : BaseMasterService, IPhuongTienService
    {
        private readonly IMapper _mapper;
        private readonly DASContext _DasContext;

        public PhuongTienService(ITravelRepositoryWrapper travelRepository, IMapper mapper, DASContext dASContext) : base(travelRepository)
        {
            _mapper = mapper;
            _travelRepo = travelRepository;
            _DasContext = dASContext;

        }

        public async Task<ServiceResult> Create(PhuongTien phuongTien)
        {
            if (phuongTien == null)
            {
                return new ServiceResultError("Thêm mới không thành công");
            }
            var valid = await validation(phuongTien);
            if (valid.Code == CommonConst.error)
            {
                return valid;
            }
            _DasContext.Add(phuongTien);
            _DasContext.SaveChanges();
            return valid;

        }

        public async Task<ServiceResult> Delete(int id)
        {
            try
            {
                var PhuongTien = _travelRepo.PhuongTien.Get(id);
                if (PhuongTien == null)
                {
                    return new ServiceResultError("Phương tiện không tồn tại hoặc đã bị xóa");
                }

                _travelRepo.PhuongTien.Delete(PhuongTien);
                _DasContext.SaveChanges();
                return new ServiceResultSuccess("Xóa Phương tiện thành công");
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

        public async Task<PhuongTien> Get(int id)
        {
            var rs = await _travelRepo.PhuongTien.FirstOrDefaultAsync(x => x.ID == id);
            return rs;
        }

        public async Task<List<PhuongTien>> GetList()
        {
            var phuongTien = await (from M in _travelRepo.PhuongTien.GetAll().AsNoTracking()
                                    orderby M.ID descending
                                    select M).ToListAsync();
            return phuongTien;
        }

        public async Task<List<VMPhuongTien>> SearchByCondition(string searchName)
        {
            var phuongTien = await (from M in _travelRepo.PhuongTien.GetAll().AsNoTracking()
                                    where searchName != null ? searchName.ToLower() == M.Name.ToLower() : true
                                    select new VMPhuongTien
                                    {
                                        Name = M.Name,
                                        ID = M.ID,
                                    }).ToListAsync();
            return phuongTien;
        }
        public async Task<VMPhuongTien> GetVmThongTinPhuongTien(int id)
        {
            var phuongTien = _travelRepo.PhuongTien.FirstOrDefault(x => x.ID == id);
            var vmPhuongTien = new VMPhuongTien();
            vmPhuongTien.PhuongTien = phuongTien;

            return vmPhuongTien;
        }

        public async Task<ServiceResult> update(PhuongTien phuongTien)
        {
            var phuongTienOld = from m in _travelRepo.Menu.GetAll()
                                where m.ID == phuongTien.ID
                                select new PhuongTien
                                {
                                    Name = phuongTien.Name,
                                    ID = phuongTien.ID,
                                    Code = phuongTien.Code,
                                    Seating = phuongTien.Seating,
                                    LicensePlates = phuongTien.LicensePlates,
                                    Color = phuongTien.Color,
                                    Manufacturer = phuongTien.Manufacturer,
                                    Status = phuongTien.Status,
                                    Description = phuongTien.Description,
                                    Active = phuongTien.Active,
                                }
                           ;

            if (phuongTienOld == null)
            {
                return new ServiceResultError("Phương tiện hiện không tồn tại hoặc đã bị xóa");
            }
            var valid = await validation(phuongTien);
            if (valid.Code == CommonConst.error)
            {
                return valid;
            }
            await _travelRepo.PhuongTien.UpdateAsync(phuongTienOld);
            _DasContext.SaveChanges();
            return new ServiceResultSuccess("Chỉnh sửa thành công");
        }

        public async Task<ServiceResult> validation(PhuongTien phuongTien)
        {
            var checkName = (from m in _travelRepo.PhuongTien.GetAll().AsNoTracking()
                             where m.Name == phuongTien.Name
                             select m);
            if (checkName.Count() != 0 )
            {
                return new ServiceResultError($"Phương tiện {phuongTien.Name} đã tồn tại");

            }
            if (phuongTien.Name == string.Empty || phuongTien.Name == null)
            {
                return new ServiceResultError("Tên không được bỏ trống");
            }
            if (phuongTien.Code == string.Empty || phuongTien.Code == null)
            {
                return new ServiceResultError("Code không được bỏ trống");
            }
            if (phuongTien.LicensePlates == string.Empty || phuongTien.LicensePlates == null)
            {
                return new ServiceResultError("Biển số không được bỏ trống");
            }
            return new ServiceResultSuccess("Thêm mới thành công");
        }
    }
}
