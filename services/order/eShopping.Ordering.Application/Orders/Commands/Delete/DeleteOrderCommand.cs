using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Ordering.Application.Orders.Commands.Delete
{
    public record DeleteOrderCommand(Guid Id) : ICommand<Result>;
}