using eShopping.Basket.Application.Grpcs;
using eShopping.Basket.Core.Entities.ShoppingCartAggregate;
using eShopping.Basket.Core.Repositories;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Basket.Application.Baskets.Commands.Create
{
    public class CreateShoppingCartHandler(IBasketRepository basketRepository, DiscountGrpcService discountGrpcService) : ICommandHandler<CreateShoppingCartCommand, Result<ShoppingCartDto>>
    {
        public async Task<Result<ShoppingCartDto>> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var items = BasketMapper.Mapper.Map<List<ShoppingCartItem>>(request.Items);
            foreach (var item in items)
            {
                var coupon = await discountGrpcService.GetDiscount(item.ProductId);
                item.Price -= coupon.Amount;
            }

            var shoppingCart = await basketRepository.UpdateBasket(new ShoppingCart
            {
                UserName = request.Username,
                Items = items
            });
            var shoppingCartDto = BasketMapper.Mapper.Map<ShoppingCartDto>(shoppingCart);
            return new Result<ShoppingCartDto>(shoppingCartDto);
        }
    }
}