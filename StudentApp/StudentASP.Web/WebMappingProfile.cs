using AutoMapper;
using StudentASP.Domain.Models;
using StudentASP.ViewModels;

namespace StudentASP.Web
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<StudentListViewModel, Student>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Student, StudentListViewModel>().ReverseMap();
        }
        
    }
}
