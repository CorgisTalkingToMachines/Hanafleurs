using API.Domain.Entities;
using API.Domain.Services;
using API.Infrastructure.Authentification;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Infrastructure.Authentifications.Jwt
{
    public class JwtTokenService : ITokenService
    {
        private readonly AuthConfiguration _authConfiguration;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public JwtTokenService(IOptions<AuthConfiguration> authConfiguration)
        {
            _authConfiguration = authConfiguration.Value;
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public string GenerateToken(User user)
        {
            return JwtHelper.GenerateToken(user, _authConfiguration);
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            throw new NotImplementedException();
        }

        public bool ValidateToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return false;

            try
            {
                // Debug : analyser le token avant validation
                // JsonWebTokenHandler instead of JwtSecurityTokenHandler to handle read and write jwt for single Audience instead of Audiences ? ToDo
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var tokenValidationParameters = GetTokenValidationParameters();

                _tokenHandler.ValidateToken
                (
                    token,
                    tokenValidationParameters,
                    out SecurityToken validatedToken
                 );


                return validatedToken is JwtSecurityToken jwt &&
                       jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
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
            };
        }
    }
}
