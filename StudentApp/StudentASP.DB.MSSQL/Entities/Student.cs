﻿using System.Collections.Generic;

namespace StudentASP.DataAccess.MSSQL.Entities
{

    public class Student : Person
    {
        public Group Group { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Score> Scores { get; set; }

    }
}
