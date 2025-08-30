namespace API.Application.DataObjects.Results
{
    public interface IResult<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public T Data { get; set; }
        public ErrorType ErrorType { get; set; }
    }
}
