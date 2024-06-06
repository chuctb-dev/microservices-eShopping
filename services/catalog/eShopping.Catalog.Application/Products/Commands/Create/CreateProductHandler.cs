using eShopping.Catalog.Core.Entities.ProductAggregate;
using eShopping.Catalog.Core.Repositories;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Catalog.Application.Products.Commands.Create
{
    public class CreateProductHandler(IProductRepository productRepository) : ICommandHandler<CreateProductCommand, Result<ProductDto>>
    {
        public async Task<Result<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = CatalogMapper.Mapper.Map<Product>(request)
                ?? throw new ApplicationException("There is an issue with mapping while creating new product");

            var newProduct = await productRepository.CreateProduct(productEntity);
            var productDto = CatalogMapper.Mapper.Map<ProductDto>(newProduct);
            return new Result<ProductDto>(productDto);
        }
    }
}