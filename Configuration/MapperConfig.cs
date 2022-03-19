using AutoMapper;
using LeaveManagementSystemIndividual.Models;
using LeaveManagementSystemIndividual.ViewModels;

namespace LeaveManagementSystemIndividual.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
        }
    }
}
