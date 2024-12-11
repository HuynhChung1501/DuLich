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
            CreateMap<VMMenu, Menu>()
            .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Menu, VMMenu>()
            .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ThongTinPhuongTien, ThongTinPhuongTien>()
            .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ThongTinChuyenDi, ThongTinChuyenDi>()
            .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<VMAccount, Account>()

            .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<VMTour, Tour>()
            .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<DatTour, DatTour>()
            .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<KhachSan, DatTour>()
            .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
