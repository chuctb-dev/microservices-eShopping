using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;

namespace eShopping.Ordering.Application.Orders.Queries.Get
{
    public record GetOrderListQuery(string Username) : IQuery<Result<List<OrderDto>>>;
}