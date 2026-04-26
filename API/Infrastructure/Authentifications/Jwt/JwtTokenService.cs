using API.Domain.Entities;
using API.Domain.Services;
using API.Infrastructure.Authentification;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace API.Infrastructure.Authentifications.Jwt
{
    public class JwtTokenService : ITokenService
    {
        private readonly AuthConfiguration _authConfiguration;
        private readonly JsonWebTokenHandler _tokenHandler;

        public JwtTokenService(IOptions<AuthConfiguration> authConfiguration)
        {
            _authConfiguration = authConfiguration.Value;
            _tokenHandler = new JsonWebTokenHandler();
        }

        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authConfiguration.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.Value),
            }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = credentials,
                Issuer = _authConfiguration.Issuer,
                Audience = _authConfiguration.Audience
            };

            return _tokenHandler.CreateToken(tokenDescriptor);
        }

        public async Task<ClaimsPrincipal?> GetPrincipalFromTokenAsync(string token)
        {
            var tokenValidationParameters = GetTokenValidationParameters();

            try
            {
                var result = await _tokenHandler.ValidateTokenAsync(token, tokenValidationParameters);
                return result.IsValid ? new ClaimsPrincipal(result.ClaimsIdentity) : null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> ValidateTokenAsync(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return false;

            try
            {
                var tokenValidationParameters = GetTokenValidationParameters();
                var result = await _tokenHandler.ValidateTokenAsync(token, tokenValidationParameters);
                return result.IsValid;
            }
            catch
            {
                return false;
            }
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _authConfiguration.Issuer,
                ValidAudience = _authConfiguration.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_authConfiguration.Key)),
                ClockSkew = TimeSpan.FromMinutes(5) // Tolérance pour les décalages d'horloge
            };
        }
    }
}
