using eShopping.Basket.Core.Repositories;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Basket.Application.Baskets.Commands.Delete
{
    public class DeleteBasketByUsernameHandler(IBasketRepository basketRepository) : ICommandHandler<DeleteBasketByUsernameCommand, Result>
    {
        public async Task<Result> Handle(DeleteBasketByUsernameCommand request, CancellationToken cancellationToken)
        {
            await basketRepository.DeleteBasket(request.Username);
            return new Result();
        }
    }
}