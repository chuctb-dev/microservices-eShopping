using eShopping.Basket.Core.AppSettings;
using eShopping.Basket.Core.Repositories;
using eShopping.Basket.Infrastructure.Repositories;
using eShopping.SharedKernel.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using StackExchange.Redis;

namespace eShopping.Basket.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var dbOptions = configuration.GetOptions<DbConnectOptions>();

            // ADD DB + HealthChecks
            services.AddHealthChecks().AddRedis(dbOptions.ConnectionString, "Redis Health", HealthStatus.Degraded);
            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(dbOptions.ConnectionString));

            // ADD CONTEXT + REPOSITORY
            services
                .AddScoped<IBasketRepository, BasketRepository>();
            return services;
        }
    }
}