using System.Runtime.CompilerServices;
using API.Domain.ValueObjects;

namespace API.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PasswordHash { get; set; }
        public string? ExternalProvider  { get; set; }
        public string? ExternalProviderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public Role Role { get; set; }

        private User() { }

        public static User Create(string username, string email, string passwordHash)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                Email = email,
                PasswordHash = passwordHash,
                Role = Role.Customer,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
            };
        }

        public static User CreateFromExternalProvider(string username, string email, string provider,
            string providerId)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                Email = email,
                PasswordHash = null,
                Role = Role.Customer,
                ExternalProvider = provider,
                ExternalProviderId = providerId,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };
        }
    }
}
