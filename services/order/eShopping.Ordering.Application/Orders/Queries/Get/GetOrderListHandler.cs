using AutoMapper;
using eShopping.Ordering.Infrastructure.Repositories.Uow;
using eShopping.SharedKernel.MediatR;
using eShopping.SharedKernel.Results;
using Microsoft.EntityFrameworkCore;

namespace eShopping.Ordering.Application.Orders.Queries.Get
{
    public class GetOrderListHandler(IUnitOfWork unitOfWork, IMapper mapper) : IQueryHandler<GetOrderListQuery, Result<List<OrderDto>>>
    {
        public async Task<Result<List<OrderDto>>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orders = await unitOfWork.OrderRepository.GetQueryable()
                .Where(o => o.Username == request.Username)
                .ToListAsync();
            return new Result<List<OrderDto>>(mapper.Map<List<OrderDto>>(orders));
        }
    }
}