using API.Models;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeModel>()
                .ForMember(d => d.EmployeeAttendanceModels, o => o.MapFrom(s => s.EmployeeAttendance))
                .ReverseMap();
            CreateMap<EmployeeAttendance, EmployeeAttendanceModel>()
                .ForMember(d => d.EmpolyeeName, o => o.MapFrom(s => s.Employee.Name))
                .ReverseMap();
        }
    }
}
