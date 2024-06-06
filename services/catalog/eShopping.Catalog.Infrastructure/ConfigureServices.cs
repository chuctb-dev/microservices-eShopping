using eShopping.Catalog.Core.AppSettings;
using eShopping.Catalog.Core.Repositories;
using eShopping.Catalog.Infrastructure.Data.Context;
using eShopping.Catalog.Infrastructure.Repositories;
using eShopping.SharedKernel.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

namespace eShopping.Catalog.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetOptions<DbConnectOptions>();

            // ADD DB
            services.AddHealthChecks()
            .AddMongoDb(options.ConnectionString, "Catalog MongoDb Health Check",
                HealthStatus.Degraded);

            // ADD DI IMongoClient
            services.AddSingleton<IMongoClient>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var options = configuration.GetOptions<DbConnectOptions>();
                var logger = sp.GetRequiredService<ILogger<CatalogContext>>();

                var clientSettings = MongoClientSettings.FromConnectionString(options.ConnectionString);
                clientSettings.ClusterConfigurator = cb =>
                {
                    cb.Subscribe<CommandStartedEvent>(e =>
                    {
                        logger.LogInformation($"[MONGO DB] Command Started: {e.CommandName} => {e.Command.ToJson()}");
                    });
                };

                return new MongoClient(clientSettings);
            });

            // ADD CONTEXT + REPOSITORY
            services
                .AddScoped<ICatalogContext, CatalogContext>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IBrandRepository, BrandRepository>()
                .AddScoped<IProductTypeRepository, ProductTypeRepository>();

            ConfigureMongoDb();

            return services;
        }

        private static void ConfigureMongoDb()
        {
            ConventionRegistry.Register("Conventions",
                    new ConventionPack
                    {
                    new CamelCaseElementNameConvention(), // Convert element names to camel case
                    new EnumRepresentationConvention(BsonType.String), // Serialize enums as strings
                    new IgnoreExtraElementsConvention(true), // Ignore extra elements when deserializing
                    new IgnoreIfNullConvention(true) // Ignore null values when serializing
                    }, _ => true);
        }
    }
}