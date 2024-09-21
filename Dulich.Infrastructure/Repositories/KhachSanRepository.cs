using Dulich.Domain.Models;
using Dulich.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulich.Infrastructure.Repositories
{
    public class KhachSanRepository : DasBaseRepository<KhachSan>, IKhachSanRepository
    {
        public KhachSanRepository(DASContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
