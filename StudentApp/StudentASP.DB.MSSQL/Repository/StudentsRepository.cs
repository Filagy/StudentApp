using StudentASP.DataAccess.MSSQL.Entities;
using StudentASP.Domain.Interfaces;
using StudentASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.DataAccess.MSSQL.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly StudentAppDbContext _studentAppDbContext;
        public StudentsRepository(StudentAppDbContext appDbContext)
        {
            _studentAppDbContext = appDbContext;
        }

        public Task<List<Domain.Models.Student>> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Models.Student>> GetBadStudents()
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Models.Student>> GetExcellentStudents()
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Models.Student>> GetGoodStudents()
        {
            throw new NotImplementedException();
        }
    }
}
