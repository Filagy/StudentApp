using AutoMapper;
using StudentASP.Domain;

namespace StudentASP.DataAccess.MSSQL
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Domain.Models.Student, Entities.Student>().ReverseMap();
        }
    }
}
