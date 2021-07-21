using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StudentASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP
{
    public class DbObjects
    {
        public static void Initial(AppDbContext context)
        {
            
            if (!context.Students.Any())
            {
                var teacherClassroom1 = new Teacher()
                {
                    FirstName = "Ludmila",
                    LastName = "Fedorova"
                };
                var teacherClassroom2 = new Teacher()
                {
                    FirstName = "Victoria",
                    LastName = "Volkova"
                };
                context.Teachers.AddRange(teacherClassroom1, teacherClassroom2);


                var history = new Subject()
                {
                    Name = "History",
                    Score = 4,
                    Date = DateTime.Parse("2021-08-12")
                };
                var eng = new Subject()
                {
                    Name = "English",
                    Score = 5,
                    Date = DateTime.Parse("2021-05-03")
                };
                var geo = new Subject()
                {
                    Name = "Geography",
                    Score = 4,
                    Date = DateTime.Parse("2021-07-17")
                };

                var history2 = new Subject()
                {
                    Name = "History",
                    Score = 2,
                    Date = DateTime.Parse("2021-05-12")
                };
                var eng2 = new Subject()
                {
                    Name = "English",
                    Score = 3,
                    Date = DateTime.Parse("2021-08-03")
                };
                var geo2 = new Subject()
                {
                    Name = "Geography",
                    Score = 2,
                    Date = DateTime.Parse("2021-02-17")
                };

                var history3 = new Subject()
                {
                    Name = "History",
                    Score = 5,
                    Date = DateTime.Parse("2021-11-12")
                };
                var eng3 = new Subject()
                {
                    Name = "English",
                    Score = 5,
                    Date = DateTime.Parse("2021-03-03")
                };
                var geo3 = new Subject()
                {
                    Name = "Geography",
                    Score = 5,
                    Date = DateTime.Parse("2021-09-17")
                };
                var list1 = new List<Subject>() { history, eng, geo };
                context.Subjects.AddRange(list1);

                var list2 = new List<Subject>() { history2, eng2, geo2 };
                context.Subjects.AddRange(list2);

                var list3 = new List<Subject>() { history3, eng3, geo3 };
                context.Subjects.AddRange(list3);
                
                
                var listStudents = new List<Student>()
                {
                    new Student()
                    {
                        FirstName = "Vasiliy",
                        LastName = "Novikov",
                        NumberGroup = 344,
                        Subjects = list1,
                        TeacherClassroom = teacherClassroom1
                    },

                    new Student()
                    {
                        FirstName = "Victor",
                        LastName = "Voronov",
                        NumberGroup = 243,
                        Subjects = list2,
                        TeacherClassroom = teacherClassroom2
                    },

                    new Student()
                    {
                        FirstName = "Mihail",
                        LastName = "Smolov",
                        NumberGroup = 349,
                        Subjects = list3,
                        TeacherClassroom = teacherClassroom1
                    },
                };
                context.Students.AddRange(listStudents);
                context.SaveChanges();
            }
        }
    }
}
