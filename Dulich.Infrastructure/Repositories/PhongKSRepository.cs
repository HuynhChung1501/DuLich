using Dulich.Domain.Models;
using Dulich.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulich.Infrastructure.Repositories
{
    public class PhongKSRepository : DasBaseRepository<PhongKS>, IPhongKSRepository
    {
        public PhongKSRepository(DASContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
