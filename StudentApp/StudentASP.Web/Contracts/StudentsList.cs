using StudentASP.Domain.Models;
using System.Collections.Generic;


namespace StudentASP.ViewModels
{
    public class StudentsList
    {
        public List<Student> AllStudents { get; set; } 
        public List<Student> BadStudents { get; set; } 
        public List<Teacher> Teachers { get; set; }
    }
}
