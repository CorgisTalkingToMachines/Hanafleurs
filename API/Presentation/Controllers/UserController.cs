using API.Application.DataObjects.Results;
using API.Application.DataObjects.Commands;
using API.Application.UseCases.Users;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RegisterUserUseCase _registerUserUseCase;

        public UserController(RegisterUserUseCase registerUserUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
        }

        [HttpPost]
        public async Task<ActionResult<RegisterUserResult>> RegisterUser (RegisterUserCommand registerUserCommand)
        {
            await _registerUserUseCase.ExecuteAsync(registerUserCommand);
            return Ok();
        }

    }
}
