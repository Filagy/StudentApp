using Microsoft.EntityFrameworkCore;
using StudentASP.DataAccess.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentASP.DataAccess.MSSQL
{
    public class DbObjects
    {
        private const int TEACHERS_COUNT = 5;
        private const int STUDENTS_COUNT = 100;
        private const int SCORES_COUNT_FOR_SUBJECT = 5;
        private const int SUBJECTS_COUNT = 5;

        private static int[] _numbersGroups = { 133, 134, 135, 136, 137 };

        private static List<Teacher> _teachers = new List<Teacher>();
        private static List<Group> _groups = new List<Group>();
        private static List<Student> _students = new List<Student>();
        private static List<Subject> _subjects = new List<Subject>();
        private static List<Score> _scores = new List<Score>();

        private static StudentAppDbContext _context;



        public static void Initial(StudentAppDbContext context)
        {
            _context = context;

            

            if (_context.Teachers.Any() == false)
            {
                AddRandomTeachers();
                _context.Teachers.AddRange(_teachers);
                _context.SaveChanges();
            }


            if (_context.Groups.Any() == false)
            {
                AddRandomGroups();
                
                _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT Groups ON;");
                _context.Groups.AddRange(_groups);
                _context.SaveChanges();
                _context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT Groups OFF;");
                
            }

            if (_context.Subjects.Any() == false)
            {
                AddRandomSubjects();
                _context.Subjects.AddRange(_subjects);
                _context.SaveChanges();
            }

            if (_context.Students.Any() == false)
            {
                AddRandomTeachers();
                _context.Teachers.AddRange(_teachers);
                context.SaveChanges();
                var teachers = _context.Teachers.ToList();
            }

            if (_context.Scores.Any() == false)
            {
                AddRandomScores();
                context.Scores.AddRange(_scores);
                context.SaveChanges();
            }




        }

        private static void AddRandomTeachers()
        {
            string teacherName = "Teacher";
            int countForTeacherName = 1;
            int teacherId = 1;

            for (int i = 0; i < TEACHERS_COUNT; i++)
            {
                var teacher = new Teacher()
                {
                    FirstName = teacherName + countForTeacherName.ToString(),
                    LastName = teacherName + countForTeacherName.ToString()
                };
                _teachers.Add(teacher);
                teacherId++;
                countForTeacherName++;
            }
        }

        private static void AddRandomGroups()
        {
            int id = 1;
            for (int i = 0; i < TEACHERS_COUNT; i++)
            {
                var group = new Group()
                {
                    NumberGroup = _numbersGroups[i],
                    TeacherClassroomId = _context.Teachers.FirstOrDefault(x => x.Id == id).Id
                };
                id++;
                _groups.Add(group);
            }
        }

        private static void AddRandomSubjects()
        {
            var titleValues = Enum.GetValues(typeof(TitleSubject));
            
            for (int i = 0; i < SUBJECTS_COUNT; i++)
            {
                var count = 1;
                var teacherName = "Teacher" + count.ToString();
                var title = (TitleSubject)titleValues.GetValue(count);

                var subject = new Subject()
                {
                    Title = title,
                    TeacherId = _context.Teachers.FirstOrDefault(x=>x.FirstName == teacherName).Id
                };
                _subjects.Add(subject);
                count++;
            }
        }

        private static void AddRandomStudents()
        {
            var studentName = "Student";
            var countForStudent = 1;
            var rand = new Random();

            for (int i = 0; i < STUDENTS_COUNT; i++)
            {
                var numberGroup = rand.Next(133, 137);
                var student = new Student()
                {
                    FirstName = studentName + countForStudent.ToString(),
                    LastName = studentName + countForStudent.ToString(),
                    NumberGroup = numberGroup,
                    Subjects = _context.Subjects.ToList()
                };
                countForStudent++;
                _students.Add(student);
            }
        }

        private static void AddRandomScores()
        {
            var rand = new Random();
            var scoreId = 1;

            foreach (var student in _context.Students)
            {
                foreach (var subject in _context.Subjects)
                {
                    for (int i = 0; i < SCORES_COUNT_FOR_SUBJECT; i++)
                    {
                        var monthForScore = rand.Next(1, 12);
                        var dayForScore = rand.Next(1, 28);

                        var score = new Score()
                        {
                            Value = rand.Next(2, 5),
                            Date = DateTime.Parse($"2021-{monthForScore}-{dayForScore}"),
                            SubjectId = _context.Subjects.FirstOrDefault(x=>x.Id == subject.Id).Id,
                            StudentId = _context.Students.FirstOrDefault(x=>x.Id == student.Id).Id
                        };
                        scoreId++;
                        _scores.Add(score);
                    }
                }
            }
        }

    }
}
