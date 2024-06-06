using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Basket.Application.Baskets.Queries.Get
{
    public record GetBasketByUserNameQuery(string Username) : IQuery<Result<ShoppingCartDto>>;
}