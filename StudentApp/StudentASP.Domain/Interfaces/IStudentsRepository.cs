using StudentASP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Domain.Interfaces
{
    public interface IStudentsRepository {
        Task<List<Student>> GetAllStudents();
        Task<List<Student>> GetExcellentStudents();
        Task<List<Student>> GetGoodStudents();
        Task<List<Student>> GetBadStudents();
    }
}
