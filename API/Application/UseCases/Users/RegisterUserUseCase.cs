using API.Application.DataObjects.Commands;
using API.Application.DataObjects.Results;
using API.Domain.Entities;
using API.Domain.Repositories.Users;
using API.Domain.Services;
using MapsterMapper;

namespace API.Application.UseCases.Users
{
    public class RegisterUserUseCase
    {
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly IWriteUserRepository _writeUserRepository;
        private readonly IReadUserRepository _readUserRepository;
        private readonly IMapper _mapper;

        public RegisterUserUseCase(IWriteUserRepository writeUserRepository, IReadUserRepository readUserRepository
            , IMapper mapper, IPasswordHashingService passwordHashingService)
        {
            _writeUserRepository = writeUserRepository;
            _mapper = mapper;
            _readUserRepository = readUserRepository;
            _passwordHashingService = passwordHashingService;
        }

        public async Task<RegisterUserResult> ExecuteAsync(RegisterUserCommand command)
        {
            var uniquenessError = await CheckUniqueness(command);
            if (uniquenessError != null) return uniquenessError;

            var user = await CreateUserFromCommand(command);
            var savedUser = await _writeUserRepository.SaveAsync(user);

            return RegisterUserResult.Success(savedUser.Id);
        }

        private async Task<RegisterUserResult?> CheckUniqueness(RegisterUserCommand command)
        {
            if (await _readUserRepository.FindByEmailAsync(command.Email) != null) return RegisterUserResult.EmailAlreadyExist();
            if (await _readUserRepository.FindByUsernameAsync(command.Username) != null) return RegisterUserResult.UsernameAlreadyExist();
            return null;
        }

        private async Task<User> CreateUserFromCommand(RegisterUserCommand command)
        {
            var user = _mapper.Map<User>(command);

            user.PasswordHash = _passwordHashingService.HashPassword(command.Password);

            return user;
        }
    }
}
