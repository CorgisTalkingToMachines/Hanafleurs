using API.Domain.Entities;

namespace API.Domain.Repositories.Users
{
    public interface IReadUserRepository
    {
        Task<User> FindByIdAsync(Guid id);
        Task<User?> FindByEmailAsync(string email);
        Task<User?> FindByUsernameAsync(string username);
    }
}
