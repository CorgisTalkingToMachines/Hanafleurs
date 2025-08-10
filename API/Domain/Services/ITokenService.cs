using API.Domain.Entities;
using System.Security.Claims;

namespace API.Domain.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);

        bool ValidateToken(string token);

        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
