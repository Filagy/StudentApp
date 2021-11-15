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

            if (!_context.Students.Any())
            {
                AddRandomTeachers();
                AddRandomGroups();
                AddRandomSubjects();
                AddRandomStudents();
                AddRandomScores();

                _context.Teachers.AddRange(_teachers);
                _context.Groups.AddRange(_groups);
                _context.Subjects.AddRange(_subjects);
                _context.Students.AddRange(_students);
                _context.Scores.AddRange(_scores);

                context.SaveChanges();
            }



        }

        private static void AddRandomTeachers()
        {
            string teacherName = "Teacher";
            int countForTeacherName = 1;

            for (int i = 0; i <= TEACHERS_COUNT; i++)
            {
                var teacher = new Teacher()
                {
                    Id = ++i,
                    FirstName = teacherName + countForTeacherName.ToString(),
                    LastName = teacherName + countForTeacherName.ToString(),
                };
                _teachers.Add(teacher);
                countForTeacherName++;
            }
        }

        private static void AddRandomGroups()
        {
            for (int i = 0; i <= TEACHERS_COUNT; i++)
            {
                var group = new Group()
                {
                    Id = ++i,
                    NumberGroup = _numbersGroups[i],
                    TeacherClassroomId = ++i
                };
            }
        }

        private static void AddRandomSubjects()
        {
            var rand = new Random();
            var titleValues = Enum.GetValues(typeof(TitleSubject));

            for (int i = 0; i < SUBJECTS_COUNT; i++)
            {
                var subject = new Subject()
                {
                    Title = (TitleSubject)titleValues.GetValue(rand.Next(1, titleValues.Length)),
                    TeacherId = ++i
                };
            }
        }

        private static void AddRandomStudents()
        {
            var studentName = "Student";
            var countForStudent = 1;
            var rand = new Random();

            for (int i = 0; i < STUDENTS_COUNT; i++)
            {
                var student = new Student()
                {
                    FirstName = studentName + countForStudent.ToString(),
                    LastName = studentName + countForStudent.ToString(),
                    GroupId = rand.Next(0,_groups.Count),
                    Subjects = _subjects
                };
                countForStudent++;
                _students.Add(student);
            }
        }

        private static void AddRandomScores()
        {
            var rand = new Random();
            
            foreach (var student in _students)
            {
                foreach (var subject in student.Subjects)
                {
                    for (int i = 0; i < SCORES_COUNT_FOR_SUBJECT; i++)
                    {
                        var monthForScore = rand.Next(1, 12);
                        var dayForScore = rand.Next(1, 28);
                        var score = new Score()
                        {
                            Id = ++i,
                            Value = rand.Next(2, 5),
                            Date = DateTime.Parse($"2021-{monthForScore}-{dayForScore}"),
                            SubjectId = subject.Id,
                            StudentId = student.Id
                        };
                        _scores.Add(score);
                    }
                }
            }
        }
     
    }
}
