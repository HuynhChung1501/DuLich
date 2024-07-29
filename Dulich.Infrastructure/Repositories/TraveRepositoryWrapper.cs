using Dulich.Infrastructure;
using Dulich.Infrastructure.Repositories;
using Dulich.Service.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Interface;

namespace Travel.Infrastructure.Repositories
{
    public class TraveRepositoryWrapper : ITravelRepositoryWrapper
    {
        private readonly DASContext _repoContext;
        public TraveRepositoryWrapper(DASContext repositoryContext)
        {
            _repoContext = repositoryContext;   
        }

        private IMenuRepository _menu;
        public IMenuRepository Menu
        {
            get
            {
                if (_menu == null)
                {
                    _menu = new MenuRepository(_repoContext);
                }
                return _menu;
            }
        }
    }
}
