using eShopping.Ordering.Core.AppSettings;
using eShopping.SharedKernel.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace eShopping.Ordering.Core
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddCoreLayer(this IServiceCollection services) =>
            services
            .AddOptionsWithValidation<DbConnectOptions>()
            .AddOptionsWithValidation<EventBusConnectOptions>();
    }
}