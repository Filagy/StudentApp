using StudentASP.DataAccess.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentASP.DataAccess.MSSQL
{
    public class DbObjects
    {
        private const int TEACHERS_COUNT = 5;
        private const int STUDENTS_COUNT = 5;
        private const int SCORES_COUNT = 5;
        private const int SUBJECTS_COUNT = 5;

        private static List<Teacher> _teachers;
        private static List<Student> _students;
        private static List<Subject> _subjects = new List<Subject>();

        private static List<Score> _scores;
        private static List<Score> _goodScores;
        private static List<Score> _badScores;

        private static StudentAppDbContext _context;



        public static void Initial(StudentAppDbContext context)
        {
            _context = context;

            //if (!context.Students.Any())
            //{
            //    AddRandomTeachers();
            //    AddTeachers(context);
            //    context.Teachers.AddRange(_teachers);
            //    context.SaveChanges();
            //}

           

        }

        private static void AddRandomTeachers()
        {
            var rand = new Random();
            string teacherFirstName = string.Empty;
            string teacherLastName = string.Empty;
            int countForTeacherName = default;

            for (int i = 0; i < TEACHERS_COUNT; i++)
            {

            }


        }

        private static void AddStudents(StudentAppDbContext context)
        {
        }

        private static void AddScores(StudentAppDbContext context)
        {
            #region RandomScores
            var scoresList = new List<Score>();
            var rand = new Random();
            var StudIddict = new Dictionary<int, int>();
            var subjectIdDict = new Dictionary<int, int>();
            int count = 1;

            foreach (var student in context.Students.ToList())
            {
                StudIddict.Add(count, student.Id);
                count++;
            }
            count = 1;
            foreach (var subject in context.Subjects.ToList())
            {
                subjectIdDict.Add(count, subject.Id);
                count++;
            }

            var enumValues = Enum.GetValues(typeof(TitleSubject));

            for (int i = 0; i <= 10; i++)
            {
                var title = (TitleSubject)enumValues.GetValue(rand.Next(1, enumValues.Length));
                var studentId = StudIddict[rand.Next(1, 6)];
                var subjectId = subjectIdDict[rand.Next(1, subjectIdDict.Values.Count)];
                var score = new Score()
                {

                    Value = rand.Next(2, 5),
                    Date = new DateTime(2021, rand.Next(1, 12), rand.Next(1, 28)),
                    SubjectId = subjectId,
                    StudentId = studentId
                };
                scoresList.Add(score);
            }
            _scores = scoresList;
            #endregion


        }

        private static void AddSubjects(StudentAppDbContext context)
        {
            var history = new Subject()
            {
                Title = TitleSubject.History,
                Teacher = context.Teachers.FirstOrDefault(x => x.LastName == "Grezin")
            };
            _subjects.Add(history);

            var eng = new Subject()
            {
                Title = TitleSubject.English,
                Teacher = context.Teachers.FirstOrDefault(x => x.LastName == "Midneva")
            };
            _subjects.Add(eng);

            var geo = new Subject()
            {
                Title = TitleSubject.Geography,
                Teacher = context.Teachers.FirstOrDefault(x => x.LastName == "Volkova")
            };
            _subjects.Add(geo);

            var bio = new Subject()
            {
                Title = TitleSubject.Biology,
                Teacher = context.Teachers.FirstOrDefault(x => x.LastName == "Grezin")
            };
            _subjects.Add(bio);
        }

        private static void AddTeachers(StudentAppDbContext context)
        {
            var teacher1 = new Teacher()
            {
                FirstName = "Ludmila",
                LastName = "Midneva"
            };

            var teacher2 = new Teacher()
            {
                FirstName = "Victoria",
                LastName = "Volkova"
            };

            var teacher3 = new Teacher()
            {
                FirstName = "Vladimir",
                LastName = "Grezin"
            };


            _teachers = new List<Teacher>() { teacher1, teacher2, teacher3 };


        }
    }
}
