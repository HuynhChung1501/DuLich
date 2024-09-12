using Dulich.Domain.Models;
using Dulich.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulich.Infrastructure.Repositories
{
    public class DatPhongRepository : DasBaseRepository<DatPhong>, IDatPhongRepository
    {
        public DatPhongRepository(DASContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
