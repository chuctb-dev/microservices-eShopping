using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Catalog.Application.Brands.Queries.Get
{
    public record GetAllBrandsQuery : IQuery<Result<List<ProductBrandDto>>>;
}