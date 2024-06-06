using eShopping.Basket.Application.Baskets.Queries.Get;
using eShopping.MassTransit;
using eShopping.MassTransit.Events;
using eShopping.MassTransit.Services;
using eShopping.SharedKernel.Exceptions;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;
using IMediator = MediatR.IMediator;

namespace eShopping.Basket.Application.Baskets.Commands.Checkout
{
    public class BasketCheckoutHandler(IMassTransitHandler massTransitHandler, IMediator mediator) : ICommandHandler<BasketCheckoutCommand, Result>
    {
        public async Task<Result> Handle(BasketCheckoutCommand request, CancellationToken cancellationToken)
        {
            var basket = await mediator.Send(new GetBasketByUserNameQuery(request.UserName));
            if (basket.Data == null) throw new NotFoundException("Basket not found");

            var @event = BasketMapper.Mapper.Map<BasketCheckoutEvent>(request);
            @event.TotalPrice = basket.Data.TotalPrice;

            await massTransitHandler.Send(RabbitMQConsts.BasketCheckoutEventQueueName, @event, typeof(BasketCheckoutEvent));
            return new Result();
        }
    }
}