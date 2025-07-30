using AutoMapper;
using LeaveManagementSystem.Application.Models.LeaveRequests;

namespace LeaveManagementSystem.Application.MappingProfiles
{
    public class LeaveTypeAutoMapperProfile : Profile
    {
        public LeaveTypeAutoMapperProfile()
        {
            CreateMap<LeaveRequestCreateVM, LeaveRequest>();

        }
    }
}
