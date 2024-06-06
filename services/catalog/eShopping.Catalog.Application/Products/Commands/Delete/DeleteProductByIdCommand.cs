using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Catalog.Application.Products.Commands.Delete
{
    public record DeleteProductByIdCommand(string Id) : ICommand<Result>;
}