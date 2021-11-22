using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentASP.DataAccess.MSSQL.Entities
{

    public class Student : Person
    {
        public int NumberGroup { get; set; }
        [ForeignKey("NumberGroup")]
        public Group Group { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Score> Scores { get; set; }

    }
}
