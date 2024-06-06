using eShopping.Catalog.Core.Entities.ProductAggregate;
using eShopping.Catalog.Core.Entities.ProductAggregate.Filters;

namespace eShopping.Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        Task<(List<Product>, int total, int page, int pageSize)> GetProducts(ProductFilter productFilter);
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByBrand(string brand);
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);
    }
}