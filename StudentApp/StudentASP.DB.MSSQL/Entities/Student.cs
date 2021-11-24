using System.Collections.Generic;

namespace StudentASP.DataAccess.MSSQL.Entities
{

    public class Student : Person
    {
        public int NumberGroup { get; set; }
        public List<Subject> Subjects { get; set; }
        public virtual List<Score> Scores { get; set; }
        public int TeacherClassroomId { get; set; }
        public virtual Teacher TeacherClassroom { get; set; }
    }
}
