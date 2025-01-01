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
    public class PhanQuyenReponsitory : DasBaseRepository<PhanQuyen>, IPhanQuyenReponsitory
    {
        public PhanQuyenReponsitory(DASContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
