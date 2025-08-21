namespace API.Application.DataObjects.Results
{
    public class LoginUserResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

        public static LoginUserResult Success(string generatedToken) => new()
        {
            IsSuccess = true,
            Message = "User logged in successfully",
            Token = generatedToken
        };

        public static LoginUserResult UserNotFound() => new()
        {
            IsSuccess = false,
            Message = "User not found with given username"
        };

        public static LoginUserResult WrongPassword() => new()
        {
            IsSuccess = false,
            Message = "Input password doesn't match with the stored user hashed password"
        };
    }
}
