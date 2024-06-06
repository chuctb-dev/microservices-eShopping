using eShopping.MassTransit.Services;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace eShopping.MassTransit
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddMassTransitLayer(this IServiceCollection services, Action<IBusRegistrationConfigurator> massTransitConfig)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            #region MassTransit

            services.AddMassTransit(massTransitConfig);

            #endregion MassTransit

            services.AddScoped<IMassTransitHandler, MassTransitHandler>();

            return services;
        }
    }
}