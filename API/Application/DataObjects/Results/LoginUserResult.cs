namespace API.Application.DataObjects.Results
{
    public class LoginUserResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        public static LoginUserResult Success() => new()
        {
            IsSuccess = true,
            Message = "User logged in successfully"
        };
    }
}
