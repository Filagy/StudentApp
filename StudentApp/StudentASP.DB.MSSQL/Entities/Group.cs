using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentASP.DataAccess.MSSQL.Entities
{
    public class Group
    {
        [Key]
        public int NumberGroup { get; set; }
        public  List<Student> Students { get; set; }
        public int TeacherClassroomId { get; set; }
        public Teacher TeacherClassroom { get; set; }
    }
}
