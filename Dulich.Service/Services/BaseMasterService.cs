using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Interface;

namespace Travel.Application.Services
{
    public class BaseMasterService 
    {
        protected ITravelRepositoryWrapper _travelRepo;
        public BaseMasterService(ITravelRepositoryWrapper dasRepository)
        {
            _travelRepo = dasRepository;
        }
    }

}
