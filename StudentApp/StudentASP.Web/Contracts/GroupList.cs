using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP.Web.Contracts
{
    public class GroupList
    {
        public IEnumerable<Group> groups { get; set; }
    }
}
