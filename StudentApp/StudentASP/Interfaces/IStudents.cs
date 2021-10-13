using StudentASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Interfaces
{
    public interface IStudents
    {
        List<Student> AllStudents { get; }
        List<Student> ExcellentStudents { get; }
        List<Student> GoodStudents { get; }
        List<Student> BadStudents { get; }
        List<Teacher> AllTeachers { get; }
    }
}
