namespace eShopping.SharedKernel.Results
{
    public class Result
    {
        public bool Success { get; set; } = true;
        public List<string> Message { get; set; } = [];

        public Result AddError(string error)
        {
            Success = false;
            Message.Add(error);
            return this;
        }
    }

    public class Result<T>(T data) : Result
    {
        public T Data { get; } = data;
    }
}