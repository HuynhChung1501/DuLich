using Dulich.Domain.Models;
using Dulich.Infrastructure;
using Dulich.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulich.Service.Service
{
    public class MenuService : IMenu
    {
        private readonly DASContext _dasContext;

        public MenuService(DASContext dasContext)
        {
            _dasContext = dasContext;
        }

        public MenuModel GetAll()
        {
            return _dasContext.MenuModels.FirstOrDefault();
        }
    }
}
