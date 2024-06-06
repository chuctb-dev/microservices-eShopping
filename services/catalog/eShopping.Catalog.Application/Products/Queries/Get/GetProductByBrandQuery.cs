using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Catalog.Application.Products.Queries.Get
{
    public record GetProductByBrandQuery(string Brand) : IQuery<Result<List<ProductDto>>>;
}