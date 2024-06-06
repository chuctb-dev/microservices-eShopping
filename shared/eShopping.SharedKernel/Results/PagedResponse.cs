using eShopping.SharedKernel.Results.Paginations;

namespace eShopping.SharedKernel.Results
{
    public class PagedResponse<T>(List<T> data, Pagination pagination)
    {
        public Pagination Pagination { get; } = pagination;
        public List<T> Data { get; } = data;
    }
}