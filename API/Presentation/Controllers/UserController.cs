using API.Application.DataObjects.Commands;
using API.Application.DataObjects.Queries;
using API.Application.DataObjects.Results;
using API.Application.UseCases.Users;
using API.Domain.Repositories.Users;
using API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RegisterUserUseCase _registerUserUseCase;
        private readonly LoginUserUseCase _loginUserUseCase;
        private readonly IReadUserRepository _readUserRepository;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly ITokenService _tokenService;

        public UserController(RegisterUserUseCase registerUserUseCase, LoginUserUseCase loginUserUseCase
            ,IReadUserRepository readUserRepository, IPasswordHashingService passwordHashingService, ITokenService tokenService)
        {
            _registerUserUseCase = registerUserUseCase;
            _loginUserUseCase = loginUserUseCase;
            _readUserRepository = readUserRepository;
            _passwordHashingService = passwordHashingService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterUserResult>> RegisterUser (RegisterUserCommand registerUserCommand)
        {
            await _registerUserUseCase.ExecuteAsync(registerUserCommand);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginUser(LoginUserQuery loginUserQuery)
        {
            var user = await _readUserRepository.FindByUsernameAsync(loginUserQuery.Username);
            var isValidPassword = _passwordHashingService.VerifyPassword(loginUserQuery.Password, user.PasswordHash);
            if (isValidPassword)
            {
                var token = _tokenService.GenerateToken(user);
                var booleanTokenShouldSucceed = _tokenService.ValidateToken(token);

                var tokenShouldFail = token + "e";
                var booleanTokenShouldFail = _tokenService.ValidateToken(token);
                return null;
            }

            return null;

        }

    }
}
