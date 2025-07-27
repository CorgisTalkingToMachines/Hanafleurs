using API.Application.DataObjects.Commands;
using API.Application.DataObjects.Results;
using API.Domain.Entities;
using API.Domain.Repositories.Users;
using API.Domain.Services;
using MapsterMapper;
using System.Reflection.Metadata.Ecma335;

namespace API.Application.UseCases.Users
{
    public class RegisterUserUseCase
    {
        private readonly IWriteUserRepository _writeUserRepository;
        private readonly IReadUserRepository _readUserRepository;
        private readonly UserDomainService _userDomainService;
        private readonly IMapper _mapper;

        public RegisterUserUseCase(IWriteUserRepository writeUserRepository, IReadUserRepository readUserRepository
            ,UserDomainService userDomainService, IMapper mapper)
        {
            _writeUserRepository = writeUserRepository;
            _userDomainService = userDomainService;
            _mapper = mapper;
            _readUserRepository = readUserRepository;
        }

        public async Task<RegisterUserResult> ExecuteAsync(RegisterUserCommand command)
        {
            var uniquenessError = await CheckUniqueness(command);
            if (uniquenessError != null) return uniquenessError;

            var user = _mapper.Map<User>(command);

            return null;
        }

        private async Task<RegisterUserResult?> CheckUniqueness(RegisterUserCommand command)
        {
            if (await _readUserRepository.FindByEmailAsync(command.Email) != null) return RegisterUserResult.EmailAlreadyExist();
            if (await _readUserRepository.FindByUsernameAsync(command.Username) != null) return RegisterUserResult.UsernameAlreadyExist();
            return null;
        }
    }
}
