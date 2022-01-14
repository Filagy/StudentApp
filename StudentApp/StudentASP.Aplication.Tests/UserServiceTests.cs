using AutoFixture;
using FluentAssertions;
using Moq;
using StudentASP.Application.Services;
using StudentASP.Domain.Models;
using StudentASP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StudentASP.Application.Tests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _usersRepositoryMock;
        private readonly UserService _service;
        private readonly Fixture _fixture;

        public UserServiceTests()
        {
            _usersRepositoryMock = new Mock<IUserRepository>();
            _service = new UserService(_usersRepositoryMock.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Create_UserIdValid_ShouldCreateNewUser()
        {
            // Arrange
            var user = _fixture.Build<User>()
                .Without(x => x.Id)
                .Create();
            var expectedUserId = _fixture.Create<int>();

            _usersRepositoryMock.Setup(x => x.Create(user))
                .ReturnsAsync(expectedUserId);

            // Act
            var userId = await _service.Create(user);

            // Assert 
            userId.Should().BeGreaterThan(default);
            userId.Should().Equals(expectedUserId);
            _usersRepositoryMock.Verify(x => x.Create(user), Times.Once);
        }

        [Fact]
        public async Task Create_UserIdIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            User user = null;
            var expectedUserId = _fixture.Create<int>();


            // Act
            var exception = await Assert
                .ThrowsAsync<ArgumentNullException>( () => _service.Create(user));

            // Assert 
            exception.Should().NotBeNull();
            _usersRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        }
    }
}
