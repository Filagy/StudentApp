using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Domain.Models
{
    public class Score
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

    }
}
