using eShopping.Catalog.Application.Products.Commands.Create;
using eShopping.Catalog.Application.Products.Commands.Update;
using eShopping.SharedKernel.MediatR.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eShopping.Catalog.Application
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

            // ADD VALIDATOR
            services.AddScoped<IValidator<CreateProductCommand>, CreateProductValidator>();
            services.AddScoped<IValidator<UpdateProductCommand>, UpdateProductValidator>();

            return services;
        }
    }
}