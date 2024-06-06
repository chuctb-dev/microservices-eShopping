using eShopping.Catalog.Core.Entities.ProductAggregate;
using eShopping.Catalog.Core.Entities.ProductAggregate.Filters;
using eShopping.Catalog.Core.Repositories;
using eShopping.Catalog.Infrastructure.Data.Context;
using eShopping.SharedKernel.Filters;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace eShopping.Catalog.Infrastructure.Repositories
{
    public class ProductRepository(ICatalogContext context) : IProductRepository
    {
        public async Task<Product> CreateProduct(Product product)
        {
            await context.Products.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
            var updateResult = await context
                .Products
                .ReplaceOneAsync(filter, product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            DeleteResult deleteResult = await context
                .Products
                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            return await context
                .Products
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByBrand(string name)
        {
            IMongoQueryable<Product> results =
                from product in context.Products.AsQueryable()
                where product.Brands.Name.ToLowerInvariant() == name.ToLowerInvariant()
                select product;

            return await results.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            IMongoQueryable<Product> results =
                from product in context.Products.AsQueryable()
                where product.Name.Contains(name)
                select product;

            return await results.ToListAsync();
        }

        public async Task<(List<Product>, int total, int page, int pageSize)> GetProducts(ProductFilter productFilter)
        {
            var builder = Builders<Product>.Filter;
            var filter = builder.Empty;

            if (!string.IsNullOrEmpty(productFilter.Keyword))
                filter &= builder.Regex(x => x.Name, new BsonRegularExpression(productFilter.Keyword, "i"));

            if (!string.IsNullOrEmpty(productFilter.BrandId))
                filter &= builder.Eq(x => x.Brands.Id, productFilter.BrandId);

            if (!string.IsNullOrEmpty(productFilter.TypeId))
                filter &= builder.Eq(x => x.Types.Id, productFilter.TypeId);

            var totalItemsTask = context.Products.CountDocumentsAsync(filter);
            var queryProductsTask = QueryProductsAsync(productFilter, filter);

            await Task.WhenAll(totalItemsTask, queryProductsTask);

            var totalItems = await totalItemsTask;
            var products = await queryProductsTask;

            long totalItem = await totalItemsTask;
            return (products, (int)totalItem, productFilter.Page, productFilter.PageSize);
        }


        private async Task<List<Product>> QueryProductsAsync(FilterBase spec, FilterDefinition<Product> filter)
        {
            var query = context.Products.Find(filter);
            var isAscending = !(spec.OrderBy?.Equals("desc", StringComparison.OrdinalIgnoreCase) ?? false);
            query = spec.SortBy?.ToLowerInvariant() switch
            {
                var sortBy when sortBy == nameof(Product.Price).ToLowerInvariant()
                    => isAscending
                        ? query.SortBy(x => x.Price).ThenBy(x => x.Name) : query.SortByDescending(x => x.Price).ThenBy(x => x.Name),
                _ => query.SortBy(x => x.Name)
            };

            query = query.Skip(spec.PageSize * (spec.Page - 1))
                         .Limit(spec.PageSize);

            return await query.ToListAsync();
        }
    }
}