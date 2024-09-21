using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.ViewModels;
using Travel.Domain.Models;

namespace Travel.Application.InterfaceService
{
    public interface IAccountService
    {
        Task<Account> GetID(int id);
        Task<List<Account>> Search(string? searchName);
        Task<Account> Create(Account account);
        Task<Account> Edit(VMAccount account);
        Task<string> Delete(int id);
    
    }
}
