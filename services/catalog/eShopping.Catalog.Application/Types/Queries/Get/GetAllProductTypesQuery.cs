using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Catalog.Application.Types.Queries.Get
{
    public record GetAllProductTypesQuery : IQuery<Result<List<ProductTypeDto>>>;
}