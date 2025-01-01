using Dulich.Infrastructure;
using Dulich.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Interface;
using Travel.Domain.Models;

namespace Travel.Infrastructure.Repositories
{
    public class PermissionReponsitory : DasBaseRepository<Permission>, IPermissionReponsitory
    {
        public PermissionReponsitory(DASContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
