using eShopping.SharedKernel.Options;
using Microsoft.Extensions.DependencyInjection;

namespace eShopping.SharedKernel.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOptionsWithValidation<TOptions>(this IServiceCollection services) where TOptions : class, IAppOptions
        {
            return services
                .AddOptions<TOptions>()
                .BindConfiguration(TOptions.ConfigSectionPath, binderOptions => binderOptions.BindNonPublicProperties = true)
                .ValidateDataAnnotations()
                .ValidateOnStart()
                .Services;
        }
    }
}