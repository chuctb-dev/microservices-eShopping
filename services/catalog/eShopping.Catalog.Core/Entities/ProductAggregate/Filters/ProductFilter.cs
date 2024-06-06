using eShopping.SharedKernel.Filters;

namespace eShopping.Catalog.Core.Entities.ProductAggregate.Filters
{
    public class ProductFilter : FilterBase
    {
        public string BrandId { get; set; }
        public string TypeId { get; set; }
    }
}