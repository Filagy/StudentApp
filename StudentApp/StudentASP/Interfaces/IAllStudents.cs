using StudentASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Interfaces
{
    public interface IAllStudents
    {
        List<Student> AllStudents { get; }
    }
}
