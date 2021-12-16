using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Web.Contracts
{
    public class Group
    {
        public int NumberGroup { get; set; }
        public string TeacherLastName { get; set; }
        public int GroupAvgScore { get; set; }
    }
}
