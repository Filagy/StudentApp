using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Models
{
    [Table("Teachers")]
    public class Teacher:Person
    {
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
