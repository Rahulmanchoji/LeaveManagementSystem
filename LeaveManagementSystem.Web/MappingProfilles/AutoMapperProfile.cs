using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.Leave_Types;

namespace LeaveManagementSystem.Web.MappingProfilles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Leavetype, LeavetypeReadOnlyVM>();
            //.ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays));   
            CreateMap<LeavetypeCreateVM, Leavetype>();
            CreateMap<LeavetypeEditVM, Leavetype>() .ReverseMap();
        }
    }
}
