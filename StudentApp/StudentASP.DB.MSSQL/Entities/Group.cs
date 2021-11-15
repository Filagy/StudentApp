using System;
using System.Collections.Generic;
using System.Text;

namespace StudentASP.DataAccess.MSSQL.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public int NumberGroup { get; set; }
        public List<Student> Students { get; set; }
        public Teacher TeacherClassroom { get; set; }
        public int TeacherClassroomId { get; set; }
    }
}
