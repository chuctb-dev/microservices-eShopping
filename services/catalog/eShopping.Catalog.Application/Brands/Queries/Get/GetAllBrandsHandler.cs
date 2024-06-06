using eShopping.Catalog.Core.Repositories;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Catalog.Application.Brands.Queries.Get
{
    public class GetAllBrandsHandler(IBrandRepository brandRepository) : IQueryHandler<GetAllBrandsQuery, Result<List<ProductBrandDto>>>
    {
        public async Task<Result<List<ProductBrandDto>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await brandRepository.GetAllBrands();
            var brandDtos = CatalogMapper.Mapper.Map<List<ProductBrandDto>>(brands);
            return new Result<List<ProductBrandDto>>(brandDtos);
        }
    }
}