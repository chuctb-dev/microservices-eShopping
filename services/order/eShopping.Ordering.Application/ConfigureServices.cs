using eShopping.SharedKernel.MediatR.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace eShopping.Ordering.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            // ADD MAPPER
            services.AddAutoMapper(typeof(ConfigureServices));

            // ADD MEDIATR
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(typeof(ConfigureServices).Assembly);
                options.AddOpenBehavior(typeof(LoggingBehavior<,>));
                options.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            //// ADD VALIDATOR
            //services.AddScoped<IValidator<CreateShoppingCartCommand>, CreateShoppingCartValidator>();

            return services;
        }
    }
}
