//using API.Domain.Entities;
//using API.Infrastructure.Authentification;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.IdentityModel.JsonWebTokens;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace API.Infrastructure.Authentifications.Jwt
//{
//    public static class JwtHelper
//    {
//            public static string GenerateToken(User user, AuthConfiguration authConfiguration)
//            {
//                var tokenHandler = new JsonWebTokenHandler();
//                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConfiguration.Key));
//                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//                var tokenDescriptor = new SecurityTokenDescriptor
//                {
//                    Subject = new ClaimsIdentity(new[]
//                    {
//                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
//                        new Claim(ClaimTypes.Email, user.Email),
//                        new Claim(ClaimTypes.Name, user.Username),
//                    },
//                    Expires = DateTime.UtcNow.AddHours(24),
//                    SigningCredentials = credentials,
//                    Issuer = _authConfiguration.Issuer,
//                    Audience = _authConfiguration.Audience
//                };

//                return tokenHandler.WriteToken(token);
//            }
//    }
//}
