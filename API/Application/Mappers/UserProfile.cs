using API.Application.Dtos.UserDtos;
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
                .NewConfig<RegisterUserRequest, User>()
                .Map(destination => destination.PasswordHash, source => source.Password);
        }
    }
}
