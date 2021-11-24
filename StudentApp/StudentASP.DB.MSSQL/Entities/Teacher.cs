using System;
using System.Collections.Generic;

namespace StudentASP.DataAccess.MSSQL.Entities
{

    public class Teacher : Person
    {
        public List<Subject> Subjects { get; set; }
        public List<Group> Groups { get; set; }
    }
}
