using AutoMapper;
using eShopping.MassTransit.Events;
using eShopping.Ordering.Application.Orders.Commands.Checkout;
using eShopping.Ordering.Application.Orders.Commands.Update;
using eShopping.Ordering.Core.Entities.OrderAggregate;

namespace eShopping.Ordering.Application
{
    public class OrderingMapperProfile : Profile
    {
        public OrderingMapperProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
            CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
        }
    }
}