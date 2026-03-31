using System.Security.Claims;
using API.Application.DataObjects.Commands;
using API.Application.DataObjects.Queries;
using API.Application.DataObjects.Results;
using API.Application.UseCases.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RegisterUserUseCase _registerUserUseCase;
        private readonly LoginUserUseCase _loginUserUseCase;
        private readonly GoogleLoginUseCase _googleLoginUseCase;

        public UserController(RegisterUserUseCase registerUserUseCase, LoginUserUseCase loginUserUseCase,  GoogleLoginUseCase googleLoginUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
            _loginUserUseCase = loginUserUseCase;
            _googleLoginUseCase = googleLoginUseCase;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterUserResult>> RegisterUser (RegisterUserCommand registerUserCommand)
        {
            var result = await _registerUserUseCase.ExecuteAsync(registerUserCommand);
            return result.ToActionResult(this);
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginUser(LoginUserQuery loginUserQuery)
        {
            var result = await _loginUserUseCase.ExecuteAsync(loginUserQuery);
            return result.ToActionResult(this);
        }

        [HttpGet("google-login")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleCallback")
            };
            
            return Challenge(properties, "Google");
        }

        [HttpGet("google-callback")]
        public async Task<IActionResult> GoogleCallback()
        {
            var result = await HttpContext.AuthenticateAsync("ExternalCookie");
            if (!result.Succeeded || result.Principal == null)
            {
                return Redirect("http://localhost:4200/auth/login?error=google-auth-failed");
            }
            
            var email = result.Principal.FindFirstValue(ClaimTypes.Email);
            var name = result.Principal.FindFirstValue(ClaimTypes.Name);
            var googleId = result.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(email))
            {
                return Redirect("http://localhost:4200/auth/login?error=no-email");
            }
            
            var googleLoginResult = await _googleLoginUseCase.ExecuteAsync(new GoogleLoginQuery(email, name ?? string.Empty, googleId ?? string.Empty));
            
            await HttpContext.SignOutAsync("ExternalCookie");

            if (!googleLoginResult.IsSuccess)
            {
                return Redirect("http://localhost:4200/auth/login?error=google-login-failed");
            }

            return Redirect($"http://localhost:4200/callback?token={googleLoginResult.Data}");
        }
        
    }
}
