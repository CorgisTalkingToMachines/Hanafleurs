namespace API.Application.DataObjects.Results
{
    public class LoginUserResult : IResult<string>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        public ErrorType ErrorType { get; set; } = ErrorType.None;

        public string Data { get; set; }

        public static LoginUserResult Success(string generatedToken) => new()
        {
            IsSuccess = true,
            Message = "User logged in successfully",
            Data = generatedToken
        };

        public static LoginUserResult UserNotFound() => new()
        {
            IsSuccess = false,
            Message = "Username or password is invalid", // Generic error for authentification response
            ErrorType = ErrorType.Unauthorized,
            Data = string.Empty
        };

        public static LoginUserResult WrongPassword() => new()
        {
            IsSuccess = false,
            Message = "Username or password is invalid", // Generic error for authentification response
            ErrorType = ErrorType.Unauthorized,
            Data = string.Empty
        };
    }
}
