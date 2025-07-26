using API.Domain.Entities;

namespace API.Domain.Repositories.Users
{
    public interface IReadUserRepository
    {
        Task SaveAsync(User user);
        Task DeleteAsync(User user);
        Task<User> FindByIdAsync(int id);
    }
}
