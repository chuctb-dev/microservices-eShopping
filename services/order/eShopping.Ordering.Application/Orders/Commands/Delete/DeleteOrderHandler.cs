using eShopping.Ordering.Infrastructure.Repositories.Uow;
using eShopping.SharedKernel.Exceptions;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Ordering.Application.Orders.Commands.Delete
{
    public class DeleteOrderHandler(IUnitOfWork unitOfWork) : ICommandHandler<DeleteOrderCommand, Result>
    {
        public async Task<Result> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await unitOfWork.OrderRepository.GetById(request.Id)
                ?? throw new NotFoundException("Order not found");

            unitOfWork.OrderRepository.Delete(order);
            await unitOfWork.SaveChangeAsync();
            return new Result();
        }
    }
}