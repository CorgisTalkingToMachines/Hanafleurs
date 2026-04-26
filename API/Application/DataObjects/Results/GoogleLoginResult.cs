namespace API.Application.DataObjects.Results;

public class GoogleLoginResult : IResult<string>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
    public ErrorType ErrorType { get; set; } = ErrorType.None;

    public static GoogleLoginResult Success(string generatedToken) => new()
    {
        IsSuccess = true,
        Message = "User logged in successfully with Google",
        Data = generatedToken
    };

    public static GoogleLoginResult AuthenticationFailed() => new()
    {
        IsSuccess = false,
        Message = "Google authentication failed",
        ErrorType = ErrorType.Unauthorized
    };

    public static GoogleLoginResult EmailNotProvided() => new()
    {
        IsSuccess = false,
        Message = "Google account did not provide an email address",
        ErrorType = ErrorType.Unauthorized
    };
}