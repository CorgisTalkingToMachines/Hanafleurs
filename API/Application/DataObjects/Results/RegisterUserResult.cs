namespace API.Application.DataObjects.Results
{
    public class RegisterUserResult
    {
        public bool IsSuccess { get; set; }
        public static RegisterUserResult Success() => new() { IsSuccess = true };
        public static RegisterUserResult EmailAlreadyExist() => new()
        {
            IsSuccess = false
            //MessagePr
        };

    }
}
