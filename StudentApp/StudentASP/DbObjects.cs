using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentASP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP
{
    public class DbObjects
    {
        private const string _PATH_TEACHERS = @"Teachers.txt";
        private static List<Teacher> _teachers;
        private static List<Student> _students;
        private static List<Subject> _subjects = new List<Subject>();
        
        private static List<Score> _scores;
        private static List<Score> _goodScores;
        private static List<Score> _badScores;

        private static AppDbContext _context;
        
        

        public static void Initial(AppDbContext context)
        {

            if (!context.Teachers.Any())
            {
                AddTeachers(context);
                context.Teachers.AddRange(_teachers);
                context.SaveChanges();
            }

            if (!context.Subjects.Any())
            {
                AddSubjects(context);
                context.Subjects.AddRange(_subjects);
                context.SaveChanges();
            }

            if (!context.Students.Any())
            {

                AddStudents(context);

                context.Students.AddRange(_students);
                context.SaveChanges();
            }

            if (!context.Scores.Any())
            {
                AddScores(context);
                context.Scores.AddRange(_scores);
                context.SaveChanges();
            }

        }

        private static void AddStudents(AppDbContext context)
        {
            var student1 = new Student()
            {
                FirstName = "Oleg",
                LastName = "Reutov",
                NumberGroup = 233,
                TeacherClassroom = context.Teachers.FirstOrDefault(x => x.LastName == "Grezin")
            };

            var student2 = new Student()
            {
                FirstName = "Alexey",
                LastName = "Minin",
                NumberGroup = 234,
                TeacherClassroom = context.Teachers.FirstOrDefault(x => x.LastName == "Midneva")
            };


            var student3 = new Student()
            {
                FirstName = "Sergey",
                LastName = "Silov",
                NumberGroup = 233,
                TeacherClassroom = context.Teachers.FirstOrDefault(x => x.LastName == "Grezin")
            };
            var student4 = new Student()
            {
                FirstName = "Fedor",
                LastName = "Zorin",
                NumberGroup = 234,
                TeacherClassroom = context.Teachers.FirstOrDefault(x => x.LastName == "Midneva")
            };
            var student5 = new Student()
            {
                FirstName = "Nika",
                LastName = "Savinova",
                NumberGroup = 233,
                TeacherClassroom = context.Teachers.FirstOrDefault(x => x.LastName == "Grezin")
            };
            var student6 = new Student()
            {
                FirstName = "Mariya",
                LastName = "Domina",
                NumberGroup = 234,
                TeacherClassroom = context.Teachers.FirstOrDefault(x => x.LastName == "Midneva")
            };
            _students = new List<Student>()
            {student1, student2, student3, student4, student5, student6 };
        }

        private static void AddScores(AppDbContext context)
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

            //#region ExellentScores
            //var Bio1 = new Score()
            //{
            //    Value = 5,
            //    Date = Convert.ToDateTime("10.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x=>x.Title == TitleSubject.Biology)
            //};
            //var Bio2 = new Score()
            //{
            //    Value = 4,
            //    Date = Convert.ToDateTime("08.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.Biology)
            //};
            //var Geo1 = new Score()
            //{
            //    Value = 5,
            //    Date = Convert.ToDateTime("05.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.Geography)
            //};
            //var Geo2 = new Score()
            //{
            //    Value = 4,
            //    Date = Convert.ToDateTime("07.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.Geography)
            //};
            //var Eng1 = new Score()
            //{
            //    Value = 5,
            //    Date = Convert.ToDateTime("08.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.English)
            //};
            //var Eng2 = new Score()
            //{
            //    Value = 4,
            //    Date = Convert.ToDateTime("10.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.English)
            //};
            //var His1 = new Score()
            //{
            //    Value = 5,
            //    Date = Convert.ToDateTime("08.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.History)
            //};
            //var His2 = new Score()
            //{
            //    Value = 4,
            //    Date = Convert.ToDateTime("08.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.History)
            //};

            //_exellentScores = new List<Score>()
            //{Bio1,Bio2, Eng1,Eng2,Geo1, Geo2, His1, His2 };

            //#endregion

            //#region GoodScores
            //var goodBio1 = new Score()
            //{
            //    Value = 4,
            //    Date = Convert.ToDateTime("10.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.Biology)
            //};
            //var goodBio2 = new Score()
            //{
            //    Value = 3,
            //    Date = Convert.ToDateTime("08.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.Biology)
            //};
            //var goodGeo1 = new Score()
            //{
            //    Value = 4,
            //    Date = Convert.ToDateTime("05.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.Geography)
            //};
            //var goodGeo2 = new Score()
            //{
            //    Value = 3,
            //    Date = Convert.ToDateTime("07.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.Geography)
            //};
            //var goodEng1 = new Score()
            //{
            //    Value = 4,
            //    Date = Convert.ToDateTime("08.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.English)
            //};
            //var goodEng2 = new Score()
            //{
            //    Value = 3,
            //    Date = Convert.ToDateTime("10.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.English)
            //};
            //var goodHis1 = new Score()
            //{
            //    Value = 4,
            //    Date = Convert.ToDateTime("08.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.History)
            //};
            //var goodHis2 = new Score()
            //{
            //    Value = 3,
            //    Date = Convert.ToDateTime("08.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.History)
            //};

            //_goodScores = new List<Score>()
            //{goodBio1, goodBio2, goodEng1, goodEng2, goodGeo1, goodGeo2, goodHis1, goodHis2 };
            //#endregion

            //#region badScores
            //var badBio1 = new Score()
            //{
            //    Value = 3,
            //    Date = Convert.ToDateTime("10.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.Biology)
            //};
            //var badBio2 = new Score()
            //{
            //    Value = 2,
            //    Date = Convert.ToDateTime("08.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.Biology)
            //};
            //var badGeo1 = new Score()
            //{
            //    Value = 3,
            //    Date = Convert.ToDateTime("05.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.Geography)
            //};
            //var badGeo2 = new Score()
            //{
            //    Value = 2,
            //    Date = Convert.ToDateTime("07.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.Geography)
            //};
            //var badEng1 = new Score()
            //{
            //    Value = 3,
            //    Date = Convert.ToDateTime("08.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.English)
            //};
            //var badEng2 = new Score()
            //{
            //    Value = 2,
            //    Date = Convert.ToDateTime("10.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.English)
            //};
            //var badHis1 = new Score()
            //{
            //    Value = 3,
            //    Date = Convert.ToDateTime("08.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.History)
            //};
            //var badHis2 = new Score()
            //{
            //    Value = 2,
            //    Date = Convert.ToDateTime("08.10.2021"),
            //    Subject = context.Subjects.FirstOrDefault(x => x.Title == TitleSubject.History)
            //};

            //_badScores = new List<Score>()
            //{badBio1, badBio2, badEng1, badEng2, badGeo1, badGeo2, badHis1, badHis2 };
            //#endregion
        }

        private static void AddSubjects(AppDbContext context)
        {
            var history = new Subject()
            {
                Title = TitleSubject.History,
                Teacher = context.Teachers.FirstOrDefault(x=>x.LastName == "Grezin")
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

        private static void AddTeachers(AppDbContext context)
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
