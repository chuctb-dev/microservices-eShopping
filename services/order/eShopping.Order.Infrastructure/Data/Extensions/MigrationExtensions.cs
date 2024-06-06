using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eShopping.Ordering.Infrastructure.Data.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using OrderDbContext dbContext =
                scope.ServiceProvider.GetRequiredService<OrderDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
