namespace API.Application.DataObjects.Results
{
    public class CreateProductResult : IResult<string>
    {
        public bool IsSuccess { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ErrorType ErrorType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public static CreateProductResult Success(string data)
        {
            throw new NotImplementedException();
        }
    }
}
