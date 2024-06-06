using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Catalog.Application.Products.Commands.Create
{
    public record CreateProductCommand(
        string Name,
        string Summary,
        string Description,
        string ImageFile,
        decimal Price,
        ProductBrandDto Brands,
        ProductTypeDto Types) : ICommand<Result<ProductDto>>;
}