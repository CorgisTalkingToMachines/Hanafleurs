using API.Domain.Entities;
using API.Domain.Repositories.Users;
using API.Domain.Services;

namespace API.Application.UseCases.Users
{
    public class RegisterUserUseCase
    {
        private readonly IWriteUserRepository _writeUserRepository;
        private readonly UserDomainService _userDomainService;

        public RegisterUserUseCase(IWriteUserRepository writeUserRepository, UserDomainService userDomainService)
        {
            _writeUserRepository = writeUserRepository;
            _userDomainService = userDomainService;
        }

        public void registerUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
