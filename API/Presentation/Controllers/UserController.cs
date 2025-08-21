using API.Application.DataObjects.Commands;
using API.Application.DataObjects.Queries;
using API.Application.DataObjects.Results;
using API.Application.UseCases.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RegisterUserUseCase _registerUserUseCase;
        private readonly LoginUserUseCase _loginUserUseCase;

        public UserController(RegisterUserUseCase registerUserUseCase, LoginUserUseCase loginUserUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
            _loginUserUseCase = loginUserUseCase;
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
            var result = await _loginUserUseCase.ExecuteAsync(loginUserQuery);
            return Ok(result);

        }

    }
}
