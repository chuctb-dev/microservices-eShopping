using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Basket.Application.Baskets.Commands.Create
{
    public record CreateShoppingCartCommand(string Username, List<ShoppingCartItemDto> Items) : ICommand<Result<ShoppingCartDto>>;
}