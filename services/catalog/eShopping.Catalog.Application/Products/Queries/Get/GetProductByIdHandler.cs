using eShopping.Catalog.Core.Repositories;
using eShopping.SharedKernel.Exceptions;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Catalog.Application.Products.Queries.Get
{
    public class GetProductByIdHandler(IProductRepository productRepository) : IQueryHandler<GetProductByIdQuery, Result<ProductDto>>
    {
        public async Task<Result<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProduct(request.Id) ?? throw new NotFoundException("Product not found");
            return new Result<ProductDto>(CatalogMapper.Mapper.Map<ProductDto>(product));
        }
    }
}