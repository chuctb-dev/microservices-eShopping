using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Catalog.Application.Products.Queries.Get
{
    public record GetProductByIdQuery(string Id) : IQuery<Result<ProductDto>>;
}