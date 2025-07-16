using API.Application.Dtos.UserDtos;
using API.Domain.Entities;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<RegisterUserResponse> RegisterUser (RegisterUserRequest registerUserRequest)
        {
            User user = _mapper.Map<User>(registerUserRequest);
            RegisterUserRequest request = _mapper.Map<RegisterUserRequest>(user);
            return Ok();
        }

    }
}
