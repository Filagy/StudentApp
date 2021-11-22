using System;
using System.Collections.Generic;
using System.Text;

namespace StudentASP.Domain.Models
{
    public class Group
    {
        public int NumberGroup { get; set; }
        public List<Student> Students { get; set; }
        public int TeacherClassroomId { get; set; }
        public Teacher TeacherClassroom { get; set; }
    }
}
