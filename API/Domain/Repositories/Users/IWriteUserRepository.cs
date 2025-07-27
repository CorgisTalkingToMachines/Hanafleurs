using API.Domain.Entities;

namespace API.Domain.Repositories.Users
{
    public interface IWriteUserRepository
    {
        Task SaveAsync(User user);
        Task DeleteAsync(User user);
    }
}
