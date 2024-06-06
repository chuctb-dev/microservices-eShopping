namespace eShopping.SharedKernel.Results
{
    public class QueryResult<T>(List<T> data, int total, int page, int pageSize)
    {
        public int Total { get; } = total;
        public List<T> Data { get; set; } = data;
        public int Page { get; } = page;
        public int PageSize { get; } = pageSize;
    }
}