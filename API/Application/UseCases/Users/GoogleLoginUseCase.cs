using API.Application.DataObjects.Queries;
using API.Application.DataObjects.Results;
using API.Domain.Entities;
using API.Domain.Repositories.Users;
using API.Domain.Services;

namespace API.Application.UseCases.Users;

public class GoogleLoginUseCase
{
    private readonly IReadUserRepository _readUserRepository;
    private readonly IWriteUserRepository _writeUserRepository;
    private readonly ITokenService _tokenService;

    public GoogleLoginUseCase(IReadUserRepository readUserRepository, IWriteUserRepository writeUserRepository ,ITokenService tokenService)
    {
        _readUserRepository = readUserRepository;
        _writeUserRepository = writeUserRepository;
        _tokenService = tokenService;
    }
    
    public async Task<GoogleLoginResult?> ExecuteAsync(GoogleLoginQuery query)
    {
        var user = await _readUserRepository.FindByEmailAsync(query.Email);
        if (user == null) // sign up the user
        {
            var newUser = User.CreateFromExternalProvider(
                query.Name,
                query.Email,
                "Google",
                query.GoogleId);
            
            await _writeUserRepository.SaveAsync(newUser);
            return GoogleLoginResult.Success(_tokenService.GenerateToken(newUser));
        }

        if (user.ExternalProvider != "Google")
        {
            return GoogleLoginResult.AuthenticationFailed();
        }

        return GoogleLoginResult.Success(_tokenService.GenerateToken(user));
    }
}