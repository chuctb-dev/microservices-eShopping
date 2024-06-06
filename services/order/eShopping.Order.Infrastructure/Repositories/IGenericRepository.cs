namespace eShopping.Ordering.Infrastructure.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetQueryable(bool isUpdate = false);
        Task<T> GetById(Guid id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}