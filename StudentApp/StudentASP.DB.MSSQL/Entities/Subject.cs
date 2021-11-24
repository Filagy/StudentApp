using System.Collections.Generic;

namespace StudentASP.DataAccess.MSSQL.Entities
{
    public enum TitleSubject
    {
        History,
        Math,
        Geography,
        English,
        Biology
    }
    public class Subject
    {
        public int Id { get; set; }
        public TitleSubject Title { get; set; }
        public List<Score> Scores { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

    }
}
