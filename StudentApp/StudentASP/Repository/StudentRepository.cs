using Microsoft.EntityFrameworkCore;
using StudentASP.Interfaces;
using StudentASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Repository
{
    public class StudentRepository : IAllStudents
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Student> AllStudents =>
            _appDbContext.Students.Include(c => c.Subjects).Include(v => v.TeacherClassroom).ToList();
    }
}
