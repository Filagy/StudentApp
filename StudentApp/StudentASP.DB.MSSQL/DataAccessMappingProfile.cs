using AutoMapper;
using StudentASP.Domain;

namespace StudentASP.DataAccess.MSSQL
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Domain.Models.Student, Entities.Student>().ReverseMap();
            CreateMap<Domain.Models.Score, Entities.Score>().ReverseMap();
            CreateMap<Domain.Models.Teacher, Entities.Teacher>().ReverseMap();
            CreateMap<Domain.Models.Subject, Entities.Subject>().ReverseMap();
            CreateMap<Domain.Models.Group, Entities.Group>().ReverseMap();
        }
    }
}
