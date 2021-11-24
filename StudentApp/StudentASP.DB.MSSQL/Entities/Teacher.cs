using System;
using System.Collections.Generic;

namespace StudentASP.DataAccess.MSSQL.Entities
{

    public class Teacher : Person
    {
        public virtual List<Subject> Subjects { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
