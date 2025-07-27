namespace API.Application.DataObjects.Results
{
    public class RegisterUserResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public static RegisterUserResult Success() => new() { IsSuccess = true };
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
