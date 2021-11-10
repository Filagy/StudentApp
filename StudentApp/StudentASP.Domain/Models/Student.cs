using System.Collections.Generic;

namespace StudentASP.Domain.Models
{

    public class Student : Person
    {
        public int NumberGroup { get; set; }
        public virtual List<Subject> Subjects { get; set; }
        public virtual List<Score> Scores { get; set; }
        public int TeacherClassroomId { get; set; }
        public virtual Teacher TeacherClassroom { get; set; }
    }
}
