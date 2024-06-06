using eShopping.Catalog.Core.Entities.ProductAggregate;
using MongoDB.Driver;

namespace eShopping.Catalog.Infrastructure.Data.Context
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
        IMongoCollection<ProductBrand> Brands { get; }
        IMongoCollection<ProductType> Types { get; }
    }
}