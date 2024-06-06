using Microsoft.EntityFrameworkCore;

namespace eShopping.Discount.Api.Data.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using DiscountDbContext dbContext =
                scope.ServiceProvider.GetRequiredService<DiscountDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
