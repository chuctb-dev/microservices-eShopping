using eShopping.Catalog.Core.Entities.ProductAggregate;
using eShopping.Catalog.Core.Repositories;
using eShopping.Catalog.Infrastructure.Data.Context;
using MongoDB.Driver;

namespace eShopping.Catalog.Infrastructure.Repositories
{
    public class BrandRepository(ICatalogContext context) : IBrandRepository
    {
        public async Task<IEnumerable<ProductBrand>> GetAllBrands()
        {
            return await context
                .Brands
                .Find(b => true)
                .ToListAsync();
        }
    }
}