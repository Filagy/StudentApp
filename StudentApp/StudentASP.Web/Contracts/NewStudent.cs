using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Web.Contracts
{
    public class NewStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberGroup { get; set; }
    }
}
