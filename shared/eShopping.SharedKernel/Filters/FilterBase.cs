namespace eShopping.SharedKernel.Filters
{
    public class FilterBase
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string SortBy { get; set; }
        public string OrderBy { get; set; }
        public string Keyword { get; set; }
    }
}