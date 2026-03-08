using API.Application.DataObjects.Queries;
using API.Application.DataObjects.Results;
using API.Domain.Repositories.Users;

namespace API.Application.UseCases.Users;

public class GoogleLoginUseCase
{
    private readonly IReadUserRepository _readUserRepository;

    public GoogleLoginUseCase(IReadUserRepository readUserRepository)
    {
        _readUserRepository = readUserRepository;
    }
    
    public async Task<GoogleLoginResult?> ExecuteAsync(GoogleLoginQuery query)
    {
        var user = await _readUserRepository.FindByEmailAsync(query.Email);
    }
}