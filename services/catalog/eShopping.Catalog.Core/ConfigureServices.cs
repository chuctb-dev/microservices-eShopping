using eShopping.Catalog.Core.AppSettings;
using eShopping.SharedKernel.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace eShopping.Catalog.Core
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddCoreLayer(this IServiceCollection services) =>
            services.AddOptionsWithValidation<DbConnectOptions>();
    }
}