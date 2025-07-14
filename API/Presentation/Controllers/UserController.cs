using API.Application.Dtos.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public ActionResult<RegisterUserResponse> RegisterUser (RegisterUserRequest registerUserRequest)
        {
            return Ok();
        }

    }
}
