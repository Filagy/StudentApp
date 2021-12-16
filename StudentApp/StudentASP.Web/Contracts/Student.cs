using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Web.Contracts
{
    public class Student
    {
        public int NumberGroup { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Teacher { get; set; }
        public double AverageScore { get; set; }
    }
}
