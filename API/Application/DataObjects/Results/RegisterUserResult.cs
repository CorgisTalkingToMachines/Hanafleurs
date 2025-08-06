namespace API.Application.DataObjects.Results
{
    public class RegisterUserResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Guid UserId { get; set; }
        public static RegisterUserResult Success(Guid id) => new()
        {
            IsSuccess = true,
            UserId = id,
            Message = "User created successfully"
        };
        public static RegisterUserResult EmailAlreadyExist() => new()
        {
            IsSuccess = false,
            Message = "Mail already in use"
        };

        public static RegisterUserResult UsernameAlreadyExist() => new()
        {
            IsSuccess = false,
            Message = "Username already in use"
        };

    }
}
