using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dulich.Application.ViewModels;
using Dulich.Domain.Models;
using Travel.Application.ViewModels;
using Travel.Domain.Models;



namespace Dulich.Domain.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<VMMenu, Menu>(); 
            CreateMap<ThongTinPhuongTien, ThongTinPhuongTien>(); 
            CreateMap<VMAccount, Account>(); 
        }
    }
}
