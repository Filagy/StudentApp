using AutoMapper;
using StudentASP.Domain.Models;
using StudentASP.ViewModels;

namespace StudentASP.Web
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<Student, StudentsList>().ReverseMap();
        }
        
    }
}
