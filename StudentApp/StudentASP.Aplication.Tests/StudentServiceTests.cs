using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using StudentASP.Application.Exceptions;
using StudentASP.Application.Services;
using StudentASP.Domain.Interfaces;
using StudentASP.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StudentASP.Application.Tests
{
    public class StudentServiceTests
    {
        private readonly Mock<IStudentsRepository> _studentsRepositoryMock;
        private readonly StudentService _service;
        private readonly Fixture _fixture;

        public StudentServiceTests()
        {
            _studentsRepositoryMock = new Mock<IStudentsRepository>();
            var mapper = new Mapper(new MapperConfiguration(cfg => { }));
            _service = new StudentService(_studentsRepositoryMock.Object, mapper);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Create_StudentIsValid_ShouldCreateStudentAndReturnStudentId()
        {
            //arrange
            var expectedStudentId = 6;
            var studentValid = new Student
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                NumberGroup = 135
            };

            _studentsRepositoryMock
                .Setup(x => x.Add(studentValid))
                .ReturnsAsync(expectedStudentId);

            //act
            var result = await _service.Create(studentValid);

            //assert
            result.Should().Be(expectedStudentId);
            _studentsRepositoryMock.Verify(x => x.Add(studentValid), Times.Once);
        }

        [Fact]
        public async Task Create_StudentIsNull_ShouldThrowArgumentNullException()
        {
            //arrange
            Student student = null;

            //act
            var exception = await Assert
                .ThrowsAsync<ArgumentNullException>(() => _service.Create(student));

            //assert
            exception.Should().NotBeNull();
            exception.ParamName.Should().Equals("student");
            _studentsRepositoryMock.Verify(x => x.Add(student), Times.Never);
        }

        [Fact]
        public async Task Create_StudentIsInvalid_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var student = new Student();

            // Act
            var exception = await Assert
                .ThrowsAsync<InvalidOperationException>(() => _service.Create(student));

            // Assert 
            exception.Should().NotBeNull();
            _studentsRepositoryMock.Verify(x => x.Add(student), Times.Never);
        }

        [Fact]
        public async Task Delete_StudentIsExist_ShouldDeleteStudentAndReturnSuccessMessage()
        {
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            //arrange
            var studentId = _fixture.Create<int>();

            var existStudent = _fixture.Build<Student>()
                .With(x => x.Id, studentId)
                .Create();

            _studentsRepositoryMock
                .Setup(x => x.Get(studentId))
                .ReturnsAsync(existStudent);

            //act
            var result = await _service.Delete(studentId);

            //assert
            result.Should().Be("Success");
            _studentsRepositoryMock.Verify(x => x.Get(studentId), Times.Once);
            _studentsRepositoryMock.Verify(x => x.Delete(studentId), Times.Once);
        }

        [Fact]
        public async Task Delete_StudentIsNotExist_ShouldReturnNotFoundException()
        {
            // Arrange
            var studentId = 999999999;

            // Act
            var exception = await Assert
                .ThrowsAsync<NotFoundException>(() => _service.Delete(studentId));

            // Assert 
            exception.Should().NotBeNull();
            exception.Message.Should()
                .Equals(StudentService.STUDENT_WAS_NOT_FOUND + $"{studentId}");
            _studentsRepositoryMock.Verify(x => x.Delete(studentId), Times.Never);

        }

    }
}
