using eShopping.Catalog.Core.Entities.ProductAggregate;

namespace eShopping.Catalog.Core.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<ProductBrand>> GetAllBrands();
    }
}