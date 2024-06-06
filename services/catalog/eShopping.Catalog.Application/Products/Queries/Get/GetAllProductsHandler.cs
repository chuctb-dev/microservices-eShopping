using eShopping.Catalog.Core.Repositories;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Catalog.Application.Products.Queries.Get
{
    public class GetAllProductsHandler(IProductRepository productRepository) : IQueryHandler<GetAllProductsQuery, QueryResult<ProductDto>>
    {
        public async Task<QueryResult<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var (products, total, page, pageSize) = await productRepository.GetProducts(request.ProductFilter);
            var productDtos = CatalogMapper.Mapper.Map<List<ProductDto>>(products);

            return new QueryResult<ProductDto>(productDtos, total, page, pageSize);
        }
    }
}