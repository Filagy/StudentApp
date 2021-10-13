using StudentASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.ViewModels
{
    public class StudentListViewModel
    {
        public List<Student> AllStudents { get; set; } 
        public List<Student> BadStudents { get; set; } 
        public List<Teacher> Teachers { get; set; }
    }
}
