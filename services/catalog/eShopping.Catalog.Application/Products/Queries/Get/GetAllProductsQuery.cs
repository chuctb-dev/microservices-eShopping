using eShopping.Catalog.Core.Entities.ProductAggregate.Filters;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Catalog.Application.Products.Queries.Get
{
    public record GetAllProductsQuery(ProductFilter ProductFilter) : IQuery<QueryResult<ProductDto>>;
}