using Dulich.Domain.Models;
using Dulich.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulich.Infrastructure.Repositories
{
    public class PhuongTienRepository : DasBaseRepository<PhuongTien>, IPhuongTienRepository
    {
        public PhuongTienRepository(DASContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
