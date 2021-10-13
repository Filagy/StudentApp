﻿using Microsoft.EntityFrameworkCore;
using StudentASP.Interfaces;
using StudentASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Repository
{
    public class StudentRepository : IStudents
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Student> AllStudents =>
            _appDbContext.Students.ToList();

        public List<Teacher> AllTeachers => _appDbContext.Teachers.ToList();

        public List<Student> ExcellentStudents => throw new NotImplementedException();

        public List<Student> GoodStudents => throw new NotImplementedException();
        public List<Student> BadStudents => throw new NotImplementedException();
    }
}