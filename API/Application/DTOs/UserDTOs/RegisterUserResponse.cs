namespace API.Application.Dtos.UserDtos
{
    public class RegisterUserResponse
    {
        public string Token { get; set; }
        public DateTime Expiration {  get; set; }
    }
}
