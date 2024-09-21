using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Models;

namespace Travel.Application.InterfaceService
{
    public interface ILoginService
    {
        string GenerateToken(Account acount);
    }
}
