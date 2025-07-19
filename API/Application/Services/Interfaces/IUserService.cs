using API.Domain.Entities;

namespace API.Application.Services.Interfaces
{
    public interface IUserService
    {
        void registerUser(User user);
    }
}
