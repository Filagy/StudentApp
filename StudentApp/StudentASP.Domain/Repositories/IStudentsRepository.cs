using StudentASP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Domain.Interfaces
{
    public interface IStudentsRepository 
    {
        Task<List<Student>> Get();
        Task<Student> Get(int studentId);
        Task<int> Add(Student student);
        Task Delete(int studentId);
    }
}
