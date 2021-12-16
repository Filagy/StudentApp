using StudentASP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentASP.Domain.Services
{
    public interface IStudentsService
    {
        Task<Student> Get(int Id);
        Task<List<Student>> Get();
        Task<int> Create(Student student);
        Task<int> Update(Student student);
        Task<string> Delete(int Id);
    }
}
