using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Models
{
    [Table("Students")]
    public class Student:Person
    {
        public int NumberGroup { get; set; }
        public virtual List<Subject> Subjects { get; set; }
        public virtual Teacher TeacherClassroom { get; set; }
    }
}
