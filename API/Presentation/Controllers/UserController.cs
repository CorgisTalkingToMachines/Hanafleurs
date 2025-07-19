using API.Application.Dtos.UserDtos;
using API.Application.Services.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<RegisterUserResponse> RegisterUser (RegisterUserRequest registerUserRequest)
        {
            return Ok();
        }

    }
}
