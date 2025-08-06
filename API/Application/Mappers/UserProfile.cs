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
                .ConstructUsing(src => User.Create(src.Username, src.Email, src.Password));
        }
    }
}
