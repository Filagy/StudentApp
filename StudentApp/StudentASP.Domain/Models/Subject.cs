using System.Collections.Generic;

namespace StudentASP.Domain.Models
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
        public virtual List<Score> Scores { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

    }
}
