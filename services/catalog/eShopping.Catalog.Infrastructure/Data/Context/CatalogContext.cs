using eShopping.Catalog.Core.AppSettings;
using eShopping.Catalog.Core.Entities.ProductAggregate;
using eShopping.SharedKernel.Extensions;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace eShopping.Catalog.Infrastructure.Data.Context
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }
        public IMongoCollection<ProductBrand> Brands { get; }
        public IMongoCollection<ProductType> Types { get; }

        public CatalogContext(IConfiguration configuration, IMongoClient client)
        {
            var options = configuration.GetOptions<DbConnectOptions>();
            var database = client.GetDatabase(options.DatabaseName);
            Brands = database.GetCollection<ProductBrand>(options.BrandsCollection);
            Types = database.GetCollection<ProductType>(options.TypesCollection);
            Products = database.GetCollection<Product>(options.ProductsCollection);

            BrandContextSeed.SeedData(Brands);
            TypeContextSeed.SeedData(Types);
            CatalogContextSeed.SeedData(Products);
        }
    }
}