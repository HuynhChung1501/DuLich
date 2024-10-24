using Dulich.Domain.Models;
using Dulich.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Interface;
using Travel.Domain.Models;

namespace Dulich.Infrastructure.Repositories
{
    public class TourRepository : DasBaseRepository<Tour>, ITourRepository
    {
        public TourRepository(DASContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
