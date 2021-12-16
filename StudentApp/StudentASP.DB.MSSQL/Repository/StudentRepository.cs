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
    public class StudentRepository : IStudentsRepository
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

        public Task<int> Add(Student student)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> Get()
        {
            var students =
                await _studentAppDbContext.Students
                .Include(x => x.Scores)
                .Include(x => x.Group.TeacherClassroom)
                .ToListAsync();

            return 
                _mapper.Map<List<Entities.Student>, List<Student>>(students);
        }

        public async Task<Student> Get(int studentId)
        {
            var student =  await _studentAppDbContext.Students.FirstOrDefaultAsync(x => x.Id == studentId);
            return _mapper.Map<Entities.Student, Student>(student);
        }
    }
}
