using eShopping.Catalog.Core.Repositories;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Catalog.Application.Products.Queries.Get
{
    public class GetProductByBrandHandler(IProductRepository productRepository) : IQueryHandler<GetProductByBrandQuery, Result<List<ProductDto>>>
    {
        public async Task<Result<List<ProductDto>>> Handle(GetProductByBrandQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetProductByBrand(request.Brand);
            var productDtos = CatalogMapper.Mapper.Map<List<ProductDto>>(products);

            return new Result<List<ProductDto>>(productDtos);
        }
    }
}