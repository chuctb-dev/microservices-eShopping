using AutoMapper;
using eShopping.MassTransit.Events;
using eShopping.MassTransit.Services;
using eShopping.Ordering.Core.Entities.OrderAggregate;
using eShopping.Ordering.Infrastructure.Repositories.Uow;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Ordering.Application.Orders.Commands.Checkout
{
    public class CheckoutOrderHandler(IUnitOfWork unitOfWork, IMassTransitHandler massTransitHandler, IMapper mapper) : ICommandHandler<CheckoutOrderCommand, Result>
    {
        public async Task<Result> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var order = mapper.Map<Order>(request);
            await unitOfWork.OrderRepository.AddAsync(order);
            var saveChangeTask = unitOfWork.SaveChangeAsync();

            await massTransitHandler.Publish(new OrderCreatedEvent
            {
                Username = request.UserName,
                IsSuccess = await saveChangeTask > 0
            },
            typeof(OrderCreatedEvent));

            return new Result();
        }
    }
}