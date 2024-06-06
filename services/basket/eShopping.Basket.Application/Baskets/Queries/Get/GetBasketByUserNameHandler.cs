using eShopping.Basket.Core.Repositories;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Basket.Application.Baskets.Queries.Get
{
    public class GetBasketByUserNameHandler(IBasketRepository basketRepository) : IQueryHandler<GetBasketByUserNameQuery, Result<ShoppingCartDto>>
    {
        public async Task<Result<ShoppingCartDto>> Handle(GetBasketByUserNameQuery request, CancellationToken cancellationToken)
        {
            var shoppingCart = await basketRepository.GetBasket(request.Username);
            var shoppingCartDto = BasketMapper.Mapper.Map<ShoppingCartDto>(shoppingCart);
            return new Result<ShoppingCartDto>(shoppingCartDto);
        }
    }
}