using System.Runtime.CompilerServices;

namespace API.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        private User() { }

        public static User Create(string username, string email, string passwordHash)
        {
            return null;
        }
    }
}
