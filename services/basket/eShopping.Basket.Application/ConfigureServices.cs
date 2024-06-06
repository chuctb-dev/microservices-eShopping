using eShopping.Basket.Application.Baskets.Commands.Create;
using eShopping.Basket.Application.Grpcs;
using eShopping.Basket.Core.AppSettings;
using eShopping.Discount.Grpc.Protos;
using eShopping.SharedKernel.Extensions;
using eShopping.SharedKernel.MediatR.Behaviors;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShopping.Basket.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
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

            // ADD GRPCS
            var grpcOptions = configuration.GetOptions<GrpcConnectOptions>();
            services.AddScoped<DiscountGrpcService>();
            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(o => o.Address = new Uri(grpcOptions.DiscountUrl));

            // ADD VALIDATOR
            services.AddScoped<IValidator<CreateShoppingCartCommand>, CreateShoppingCartValidator>();

            return services;
        }
    }
}