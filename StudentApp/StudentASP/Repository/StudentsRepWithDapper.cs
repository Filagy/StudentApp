using Microsoft.Data.SqlClient;
using StudentASP.Interfaces;
using StudentASP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Repository
{

    public class StudentsRepWithDapper : IStudents
    {
        public List<Student> AllStudents => new List<Student>();

        public List<Student> ExcellentStudents => throw new NotImplementedException();

        public List<Student> GoodStudents => throw new NotImplementedException();

        public List<Student> BadStudents => throw new NotImplementedException();

        public List<Teacher> AllTeachers => throw new NotImplementedException();
    }
}
