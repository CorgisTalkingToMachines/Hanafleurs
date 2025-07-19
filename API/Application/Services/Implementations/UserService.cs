using API.Application.Services.Interfaces;
using API.Domain.Entities;
using API.Domain.Repositories;
using API.Domain.Services;

namespace API.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserDomainService _userDomainService;

        public UserService(IUserRepository userRepository, UserDomainService userDomainService)
        {
            _userRepository = userRepository;
            _userDomainService = userDomainService;
        }

        public void registerUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
