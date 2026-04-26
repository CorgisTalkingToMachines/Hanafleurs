using API.Application.DataObjects.Commands;
using API.Application.DataObjects.Results;
using API.Application.UseCases.Users;
using API.Domain.Entities;
using API.Domain.Repositories.Users;
using API.Domain.Services;
using MapsterMapper;
using NSubstitute;

namespace ApiTest.UseCases.Users
{
    public class RegisterUserUseCaseTests
    {
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly IWriteUserRepository _writeUserRepository;
        private readonly IReadUserRepository _readUserRepository;
        private readonly IMapper _mapper;
        private readonly RegisterUserUseCase _sut;

        public RegisterUserUseCaseTests()
        {
            _passwordHashingService = Substitute.For<IPasswordHashingService>();
            _writeUserRepository = Substitute.For<IWriteUserRepository>();
            _readUserRepository = Substitute.For<IReadUserRepository>();
            _mapper = Substitute.For<IMapper>();
            _sut = new RegisterUserUseCase(_writeUserRepository, _readUserRepository, _mapper, _passwordHashingService);
        }

        [Fact]
        public async Task ExecuteAsync_WhenEmailAlreadyExist_ReturnsEmailAlreadyExist()
        {
            // Arrange
            string sameEmail = "testuser@gmail.com";
            var command = new RegisterUserCommand { Username = "testuser", Email = sameEmail, Password = "testpassword" };
            _readUserRepository.FindByEmailAsync(command.Email).Returns(User.Create("testuser2", sameEmail, "hashedpassword"));

            // Act
            var result = await _sut.ExecuteAsync(command);

            // Assert
                // invariant
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorType.BadRequest, result.ErrorType);
            Assert.Equal(Guid.Empty, result.Data);

                // side effect
            await _writeUserRepository.DidNotReceive().SaveAsync(Arg.Any<User>());
        }
    }
}