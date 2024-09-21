using AutoMapper;
using Dulich.Infrastructure;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.Enums;
using Travel.Application.Helpers;
using Travel.Application.InterfaceService;
using Travel.Application.ViewModels;
using Travel.Domain.Interface;
using Travel.Domain.Models;

namespace Travel.Application.Services
{
    public class AccountService : BaseMasterService, IAccountService
    {

        private readonly IMapper _mapper;
        private readonly DASContext _DasContext;

        public AccountService(ITravelRepositoryWrapper travelRepository, IMapper mapper, DASContext dASContext) : base(travelRepository)
        {
            _mapper = mapper;
            _travelRepo = travelRepository;
            _DasContext = dASContext;
        }

        public async Task<Account> Create(Account account)
        {
            if (await _travelRepo.Account.AnyAsync(a => a.UsereName == account.UsereName))
            {
                throw new AppException($"UserName: {account.UsereName} đã tồn tại");
            }
            _DasContext.Add(account);
            _DasContext.SaveChanges();
            return account;
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                var account = await _DasContext.Accounts.FirstOrDefaultAsync(a => a.ID == id && a.Active == (int)EnumCommon.Status.Active);

                if (account == null) throw new AppException("Xóa không thành công.");

                _DasContext.Remove(account);
                _DasContext.SaveChanges();

                return $"Xóa User: {account.UsereName} thành công";
            }
            catch (Exception ex)
            {

                throw new AppException(ex.Message);
            }

        }

        public async Task<Account> Edit(VMAccount model)
        {
            try
            {
                var account = await _DasContext.Accounts.FirstOrDefaultAsync(a => a.ID == model.ID);

                if (account == null) throw new AppException("Không tìm thấy dữ liệu phù hợp");

                _mapper.Map(model, account);

                _DasContext.Update(account);
                _DasContext.SaveChanges();

                return account;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);

            }
        }

        public async Task<Account> GetID(int id)
        {
            var account = await _DasContext.Accounts.FirstOrDefaultAsync(a => a.ID == id && a.Active == (int)EnumCommon.Status.Active);

            if (account == null) throw new AppException("Không tìm thấy dữ liệu phù hợp.");
            return account;
        }

        #region Tìm kiếm theo userName và fullName
        public async Task<List<Account>> Search(string? searchName)
        {
            var accounts = await (from a in _DasContext.Accounts.AsNoTracking()
                                  where (string.IsNullOrEmpty(searchName) || a.UsereName.Contains(searchName) || a.FullName.Contains(searchName))
                                  && (a.Active == (int)EnumCommon.Status.Active)
                                  select a).ToListAsync();
            var accountResult = new List<Account>();
            foreach (var item in accounts)
            {
                accountResult.Add(new Account
                {
                    UsereName = item.UsereName,
                    FullName = item.FullName,
                    Active = item.Active,
                    Phone = item.Phone,
                    Gender = item.Gender,
                    Email = item.Email,
                    PassWord = "",
                    ID = item.ID
                });
            }

            if (accounts.Count == 0 || !accounts.Any())
            {
                throw new KeyNotFoundException("Không tìm thấy dữ liệu phù hợp");
            }

            return accountResult;
        }
        #endregion

    }
}
