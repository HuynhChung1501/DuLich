using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dulich.Application.ViewModels;
using Dulich.Domain.Models;



namespace Dulich.Domain.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<VMMenu, Menu>(); 
            CreateMap<VMPhuongTien, PhuongTien>(); 
        }
    }
}
