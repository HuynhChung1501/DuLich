using Dulich.Domain.Models;
using Dulich.Infrastructure;
using Dulich.Infrastructure.Repositories;
using Dulich.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Interface;
using Travel.Domain.Models;

namespace Travel.Infrastructure.Repositories
{
    public class AccountRepository : DasBaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(DASContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
