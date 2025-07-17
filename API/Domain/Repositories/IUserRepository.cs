using API.Domain.Entities;

namespace API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task SaveAsync(User user);
        Task DeleteAsync(User user);
        Task<User> FindByIdAsync(int id);
    }
}
