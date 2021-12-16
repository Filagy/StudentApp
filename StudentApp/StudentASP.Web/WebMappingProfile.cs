using AutoMapper;
using StudentASP.Domain.Models;
using StudentASP.Web.Contracts;
using System.Linq;

namespace StudentASP.Web
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<Domain.Models.Student, Contracts.Student>()
                .ForMember(
                    dest => dest.AverageScore,
                    opt => opt.MapFrom(
                        srs => srs.Scores.Average(x => x.Value)))
                .ForMember(
                    dest => dest.Teacher,
                    opt => opt.MapFrom(
                        src => src.Group.TeacherClassroom.LastName));
        }

    }
}
