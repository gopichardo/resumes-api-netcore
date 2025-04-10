using Core.Entity;
using Core.Repository;
using Moq;
using Core.Usecase.Users;

namespace Test.Core.Usecase.Users
{
    public class CreateUserUseCaseTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly CreateUserUseCase _createUserUseCase;

        public CreateUserUseCaseTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _createUserUseCase = new CreateUserUseCase(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task ExecuteAsync_ShouldCallInsertUser_WhenUserIsValid()
        {
            // Arrange
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Test User",
                Email = "test@mail.com"
            };

            // Act
            await _createUserUseCase.ExecuteAsync(user);

            // Assert
            _userRepositoryMock.Verify(repo => repo.InsertUser(user), Times.Once);

        }



        [Fact]
        public async Task ExecuteAsync_ShouldThrowArgumentNullException_WhenUserIsNull()
        {
            #pragma warning disable CS8604
            // Arrange
            User? user = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _createUserUseCase.ExecuteAsync(user));
        }
    }
}