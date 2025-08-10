using System.ComponentModel.DataAnnotations;

namespace API.Application.DataObjects.Queries
{
    public class LoginUserQuery
    {
        [Required]
        [StringLength(25), MinLength(3)]
        public string Username { get; init; } = string.Empty;

        [Required]
        [StringLength(50), MinLength(4)]
        public string Password { get; init; } = string.Empty;
    }
}
