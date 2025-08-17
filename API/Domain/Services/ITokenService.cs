using API.Domain.Entities;
using System.Security.Claims;

namespace API.Domain.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);

        Task<bool> ValidateTokenAsync(string token);

        Task<ClaimsPrincipal?> GetPrincipalFromTokenAsync(string token);
    }
}
