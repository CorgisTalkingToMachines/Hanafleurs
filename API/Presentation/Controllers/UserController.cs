using API.Application.DataObjects.Results;
using API.Application.Dtos.UserDtos;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {
        }

        [HttpPost]
        public ActionResult<RegisterUserResult> RegisterUser (RegisterUserCommand registerUserRequest)
        {
            return Ok();
        }

    }
}
