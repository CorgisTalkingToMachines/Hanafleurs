using API.Domain.ValueObjects;

namespace API.Domain.Entities
{
    public class User
    {
        public Guid Id { get; init; }
        public string Username { get; init; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string? PasswordHash { get; private set; }
        public string? ExternalProvider  { get; init; }
        public string? ExternalProviderId { get; init; }
        public DateTime CreatedAt { get; init; }
        public bool IsActive { get; private set; }
        public Role Role { get; private set; }

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
