using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

    }
}
