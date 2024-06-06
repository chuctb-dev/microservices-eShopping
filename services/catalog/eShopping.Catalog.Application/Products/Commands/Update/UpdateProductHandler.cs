using eShopping.Catalog.Core.Entities.ProductAggregate;
using eShopping.Catalog.Core.Repositories;
using eShopping.SharedKernel.Exceptions;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Catalog.Application.Products.Commands.Update
{
    public class UpdateProductHandler(IProductRepository productRepository) : ICommandHandler<UpdateProductCommand, Result<ProductDto>>
    {
        public async Task<Result<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProduct(request.Id) ?? throw new NotFoundException("Product not found");

            product.Name = request.Name;
            product.Summary = request.Summary;
            product.Description = request.Description;
            product.ImageFile = request.ImageFile;

            if (!product.Price.Equals(request.Price))
                product.Price = request.Price;

            if (product.Brands.Id != request.Brands.Id)
                product.Brands = new ProductBrand
                {
                    Id = request.Brands.Id,
                    Name = request.Brands.Name,
                };
            if (product.Types.Id != request.Types.Id)
                product.Types = new ProductType
                {
                    Id = request.Types.Id,
                    Name = request.Types.Name,
                };

            await productRepository.UpdateProduct(product);
            return new Result<ProductDto>(CatalogMapper.Mapper.Map<ProductDto>(product));
        }
    }
}