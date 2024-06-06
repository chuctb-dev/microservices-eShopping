using eShopping.Ordering.Core.AppSettings;
using eShopping.Ordering.Infrastructure.Data;
using eShopping.Ordering.Infrastructure.Repositories;
using eShopping.Ordering.Infrastructure.Repositories.Uow;
using eShopping.SharedKernel.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShopping.Ordering.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var dbOptions = configuration.GetOptions<DbConnectOptions>();

            // ADD DB
            services.AddHealthChecks()
                .Services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(dbOptions.ConnectionString, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                        .MigrationsAssembly(typeof(OrderDbContext).Assembly.FullName))
                        .UseSnakeCaseNamingConvention());

            // ADD REPOSITORIES, UOW
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}