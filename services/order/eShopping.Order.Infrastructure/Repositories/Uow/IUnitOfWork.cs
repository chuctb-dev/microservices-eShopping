using eShopping.Ordering.Core.Entities.OrderAggregate;

namespace eShopping.Ordering.Infrastructure.Repositories.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Order> OrderRepository { get; }
        Task<int> SaveChangeAsync();
    }
}
