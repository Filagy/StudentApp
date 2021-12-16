using AutoMapper;
using StudentASP.Application.Exceptions;
using StudentASP.Application.Validators;
using StudentASP.Domain.Interfaces;
using StudentASP.Domain.Models;
using StudentASP.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentASP.Application.Services
{
    public class StudentService : IStudentsService
    {
        private readonly IStudentsRepository _studentRepository;
        private readonly IMapper _mapper;
        public const string STUDENT_WAS_NOT_FOUND = "Student was not found with this id: ";
        

        public StudentService(
            IStudentsRepository studentRepository,
            IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }


        public async Task<int> Create(Student student)
        {
            if (student is null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var validator = new StudentValidator();
            var resultValidation = await validator.ValidateAsync(student);
            if (resultValidation.IsValid == false)
            {
                var errors = resultValidation.ToString(", ");
                throw new InvalidOperationException(errors);
            }

            return await _studentRepository.Add(student);
            
        }

        public async Task<string> Delete(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            var student = await _studentRepository.Get(studentId);
            if (student is null)
            {
                throw new NotFoundException(STUDENT_WAS_NOT_FOUND + $"{studentId}");
            }
            // validate isExist
            // remove from db
            await _studentRepository.Delete(studentId);
            var message = "Success";
            return message;
        }

        public async Task<Student> Get(int studentId)
        {
            // validate isExist
            // validate id == 0
            // get from db
            if (studentId <= default(int))
            {
                throw ExceptionHelper.CreateArgumentShouldBeGreaterException(nameof(studentId));
            }

            return await _studentRepository.Get(studentId);
        }

        public async Task<List<Student>> Get()
        {
            // get all from db
            var students = await _studentRepository.Get();
            return students;
        }

        public Task<int> Update(Student student)
        {
            // validate 
            throw new NotImplementedException();
        }
    }
}
