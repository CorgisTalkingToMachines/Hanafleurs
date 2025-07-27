using System.ComponentModel.DataAnnotations;

namespace API.Application.DataObjects.Commands
{
    public class RegisterUserCommand
    {
        [Required]
        [StringLength(25), MinLength(3)]
        public string Username { get; init; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; init; } = string.Empty;

        [Required]
        [StringLength(50), MinLength(8)]
        public string Password { get; init; } = string.Empty;
    }
}
