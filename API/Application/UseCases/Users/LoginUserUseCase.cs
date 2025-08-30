using API.Application.DataObjects.Queries;
using API.Application.DataObjects.Results;
using API.Domain.Repositories.Users;
using API.Domain.Services;

namespace API.Application.UseCases.Users
{
    public class LoginUserUseCase
    {
        private readonly IReadUserRepository _readUserRepository;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly ITokenService _tokenService;
        public LoginUserUseCase(IReadUserRepository readUserRepository, IPasswordHashingService passwordHashingService, ITokenService tokenService)
        {
            _readUserRepository = readUserRepository;
            _passwordHashingService = passwordHashingService;
            _tokenService = tokenService;
        }

        public async Task<LoginUserResult?> ExecuteAsync(LoginUserQuery query)
        {
            var user = await _readUserRepository.FindByUsernameAsync(query.Username);
            if (user == null)
            {
                return LoginUserResult.UserNotFound();
            }

            bool isPasswordValid = _passwordHashingService.VerifyCorrespondingPasswordWithStoredHashedPassword(query.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                return LoginUserResult.WrongPassword();
            }

            string generatedToken = _tokenService.GenerateToken(user);

            return LoginUserResult.Success(generatedToken);
        }
    }
}
