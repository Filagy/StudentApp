using StudentASP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Domain.Interfaces
{
    public interface IStudentRepository 
    {
        Task<List<Student>> GetAllStudentsAsync();
    }
}
