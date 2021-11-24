
using System.Collections.Generic;

namespace StudentASP.Domain.Models
{

    public class Student : Person
    {
        public int NumberGroup { get; set; }
        public Group Group { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Score> Scores { get; set; }
    }
}
