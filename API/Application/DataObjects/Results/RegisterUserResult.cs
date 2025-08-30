namespace API.Application.DataObjects.Results
{
    public class RegisterUserResult : IResult<Guid>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public Guid Data {  get; set; }
        public ErrorType ErrorType { get; set; } = ErrorType.None;

        public static RegisterUserResult Success(Guid id) => new()
        {
            IsSuccess = true,
            Data = id, // User GUID
            Message = "User created successfully"
        };
        public static RegisterUserResult EmailAlreadyExist() => new()
        {
            IsSuccess = false,
            Message = "Mail already in use",
            ErrorType = ErrorType.BadRequest,
            Data = Guid.Empty
        };

        public static RegisterUserResult UsernameAlreadyExist() => new()
        {
            IsSuccess = false,
            Message = "Username already in use",
            ErrorType = ErrorType.BadRequest,
            Data = Guid.Empty
        };

    }
}
