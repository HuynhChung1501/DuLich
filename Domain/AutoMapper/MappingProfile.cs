using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dulich.Domain.Models;
using Dulich.Domain.Models.ViewModel;



namespace Dulich.Domain.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<MenuVM, MenuModel>(); 
        }
    }
}
