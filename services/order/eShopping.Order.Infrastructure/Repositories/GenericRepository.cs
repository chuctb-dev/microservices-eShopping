using eShopping.Ordering.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eShopping.Ordering.Infrastructure.Repositories
{
    public class GenericRepository<T>(OrderDbContext context) : IGenericRepository<T> where T : class
    {
        public IQueryable<T> GetQueryable(bool isUpdate = false)
            => isUpdate
            ? context.Set<T>()
            : context.Set<T>().AsNoTracking();

        public async Task<T> GetById(Guid id)
            => await context.Set<T>().FindAsync(id);

        public async Task AddAsync(T entity)
            => await context.Set<T>().AddAsync(entity);

        public void Update(T entity)
            => context.Set<T>().Update(entity);

        public void Delete(T entity)
            => context.Set<T>().Remove(entity);
    }
}