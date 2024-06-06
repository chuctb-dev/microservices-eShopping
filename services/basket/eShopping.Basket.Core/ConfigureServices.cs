using eShopping.Basket.Core.AppSettings;
using eShopping.SharedKernel.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace eShopping.Basket.Core
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddCoreLayer(this IServiceCollection services) =>
            services.AddOptionsWithValidation<DbConnectOptions>()
            .AddOptionsWithValidation<GrpcConnectOptions>()
            .AddOptionsWithValidation<EventBusConnectOptions>();
    }
}