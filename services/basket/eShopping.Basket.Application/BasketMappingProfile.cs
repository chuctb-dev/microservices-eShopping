using AutoMapper;
using eShopping.Basket.Application.Baskets.Commands.Checkout;
using eShopping.Basket.Core.Entities.ShoppingCartAggregate;
using eShopping.MassTransit.Events;

namespace eShopping.Basket.Application
{
    public class BasketMappingProfile : Profile
    {
        public BasketMappingProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartDto>().ReverseMap();
            CreateMap<ShoppingCartItem, ShoppingCartItemDto>().ReverseMap();
            CreateMap<BasketCheckoutCommand, BasketCheckoutEvent>().ReverseMap();
        }
    }
}