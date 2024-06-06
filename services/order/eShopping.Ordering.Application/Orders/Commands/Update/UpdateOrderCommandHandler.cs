using AutoMapper;
using eShopping.Ordering.Core.Entities.OrderAggregate;
using eShopping.Ordering.Infrastructure.Repositories.Uow;
using eShopping.SharedKernel.Exceptions;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Ordering.Application.Orders.Commands.Update
{
    public class UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : ICommandHandler<UpdateOrderCommand, Result>
    {
        public async Task<Result> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await unitOfWork.OrderRepository.GetById(request.Id)
                ?? throw new NotFoundException("Order not found");

            mapper.Map(request, order, typeof(UpdateOrderCommand), typeof(Order));
            unitOfWork.OrderRepository.Update(order);
            await unitOfWork.SaveChangeAsync();
            return new Result();
        }
    }
}