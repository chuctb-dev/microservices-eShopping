using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Basket.Application.Baskets.Commands.Delete
{
    public record DeleteBasketByUsernameCommand(string Username) : ICommand<Result>;
}