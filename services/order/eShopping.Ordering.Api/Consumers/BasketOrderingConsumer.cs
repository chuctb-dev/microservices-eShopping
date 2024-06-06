using AutoMapper;
using eShopping.MassTransit.Events;
using eShopping.Ordering.Application.Orders.Commands.Checkout;
using MassTransit;
using MediatR;

namespace eShopping.Ordering.Api.Consumers
{
    public class BasketOrderingConsumer(IMediator mediator, IMapper mapper) : IConsumer<BasketCheckoutEvent>
    {
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var command = mapper.Map<CheckoutOrderCommand>(context.Message);
            await mediator.Send(command);
        }
    }
}

