using API_Practice.DTO;
using API_Practice.Models;
using AutoMapper;

namespace API_Practice.Mapping
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Emp, EmpDTO2>().ForMember(x=>x.mname,x=>x.MapFrom(x=>x.manager.mname != null ? 
            x.manager.mname:"No"));

            CreateMap<Emp, EmpDTO>();
            CreateMap<Manager, ManagerDTO>().ReverseMap();
        }
    }
}
