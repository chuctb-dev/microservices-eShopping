using eShopping.Basket.Application.Baskets.Commands.Delete;
using eShopping.MassTransit.Events;
using MassTransit;
using MediatR;

namespace eShopping.Basket.Api.Consumers
{
    public class OrderCreatedConsumer(IMediator mediator) : IConsumer<OrderCreatedEvent>
    {
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            if (context.Message.IsSuccess)
            {
                await mediator.Send(new DeleteBasketByUsernameCommand(context.Message.Username));
            }
        }
    }
}
