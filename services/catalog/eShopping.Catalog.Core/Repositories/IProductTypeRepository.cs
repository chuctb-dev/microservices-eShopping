using eShopping.Catalog.Core.Entities.ProductAggregate;

namespace eShopping.Catalog.Core.Repositories
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetAllTypes();
    }
}