using eShopping.Ordering.Core.Entities.OrderAggregate;
using eShopping.Ordering.Infrastructure.Data;

namespace eShopping.Ordering.Infrastructure.Repositories.Uow
{
    public class UnitOfWork(OrderDbContext context) : IUnitOfWork
    {
        private IGenericRepository<Order> orderRepository;
        public IGenericRepository<Order> OrderRepository
        {
            get
            {
                orderRepository ??= new GenericRepository<Order>(context);
                return orderRepository;
            }
        }

        public async Task<int> SaveChangeAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose() => context.Dispose();
    }
}