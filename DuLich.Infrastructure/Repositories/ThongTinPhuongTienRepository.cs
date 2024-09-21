using Dulich.Domain.Models;
using Dulich.Infrastructure;
using Dulich.Infrastructure.Repositories;
using Dulich.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Models;

namespace Travel.Infrastructure.Repositories
{
    public class ThongTinPhuongTienRepository : DasBaseRepository<ThongTinPhuongTien>, IThongTinPhuongTienRepository
    {
        public ThongTinPhuongTienRepository(DASContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
