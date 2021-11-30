using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentASP.Domain.Interfaces;
using StudentASP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.DataAccess.MSSQL.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DiaryAppDbContext _studentAppDbContext;
        private readonly IMapper _mapper;

        public StudentRepository(
            DiaryAppDbContext appDbContext,
            IMapper mapper)
        {
            _studentAppDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var students = 
                await _studentAppDbContext.Students
                .Include(x=>x.Scores)
                .Include(x => x.Group.TeacherClassroom)
                .ToListAsync();

            return 
                _mapper.Map<List<Entities.Student>, List<Student>>(students);
        }
    }
}
