using API.Domain.Entities;
using API.Domain.Services;
using Microsoft.AspNetCore.Identity;

namespace API.Infrastructure.Services
{
    public class PasswordHashingService : IPasswordHashingService
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public PasswordHashingService(IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool VerifyCorrespondingPasswordWithStoredHashedPassword(string inputPassword, string userHashedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, userHashedPassword, inputPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
