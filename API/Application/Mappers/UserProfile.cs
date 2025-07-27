using API.Application.DataObjects.Commands;
using API.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Mapster;

namespace API.Application.Mappers
{
    public class UserProfile : IRegister
    {
        public UserProfile()
        {
        }

        public void Register(TypeAdapterConfig configuration)
        {
            configuration
                .NewConfig<RegisterUserCommand, User>()
                .Map(destination => destination.PasswordHash, source => source.Password)
                .TwoWays()
                .Map(source => source.PasswordHash, destination => destination.Password);
        }
    }
}
