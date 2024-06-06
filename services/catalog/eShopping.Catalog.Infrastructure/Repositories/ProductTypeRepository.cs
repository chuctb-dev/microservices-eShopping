using eShopping.Catalog.Core.Entities.ProductAggregate;
using eShopping.Catalog.Core.Repositories;
using eShopping.Catalog.Infrastructure.Data.Context;
using MongoDB.Driver;

namespace eShopping.Catalog.Infrastructure.Repositories
{
    public class ProductTypeRepository(ICatalogContext context) : IProductTypeRepository
    {
        public async Task<IEnumerable<ProductType>> GetAllTypes()
        {
            return await context
                .Types
                .Find(t => true)
                .ToListAsync();
        }
    }
}