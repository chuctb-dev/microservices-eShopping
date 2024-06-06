using eShopping.Catalog.Core.Repositories;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Catalog.Application.Products.Commands.Delete
{
    public class DeleteProductByIdHandler(IProductRepository productRepository) : ICommandHandler<DeleteProductByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var result = await productRepository.DeleteProduct(request.Id);
            return result ? new Result() : throw new Exception($"An error occurred when deleting document with id {request.Id}");
        }
    }
}