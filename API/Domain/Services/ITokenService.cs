using API.Domain.Entities;
using System.Security.Claims;

namespace API.Domain.Services
{
    public interface ITokenService
    {
        public string GenerateToken(User user);

        public Task<bool> ValidateTokenAsync(string token);

        public Task<ClaimsPrincipal?> GetPrincipalFromTokenAsync(string token);
    }
}
