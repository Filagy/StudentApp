using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Models
{
    
    public class Teacher:Person
    {
        public virtual List<Subject> Subjects { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
