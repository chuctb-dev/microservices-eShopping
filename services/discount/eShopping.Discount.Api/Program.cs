using eShopping.Discount.Api.Commons;
using eShopping.Discount.Api.Data;
using eShopping.Discount.Api.Data.Extensions;
using eShopping.Discount.Api.Features.Discounts.Commands.Create;
using eShopping.Discount.Api.Features.Discounts.Commands.Update;
using eShopping.Discount.Api.Grpcs.Discounts;
using eShopping.SharedKernel.Extensions;
using eShopping.SharedKernel.MediatR.Behaviors;
using eShopping.SharedKernel.Middlewares;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.

// ADD CQRS
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(DbConnectOptions).Assembly);
    options.AddOpenBehavior(typeof(LoggingBehavior<,>));
    options.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

// ADD MAPPER
builder.Services.AddAutoMapper(typeof(DbConnectOptions));

// ADD APPSETTINGS
builder.Services.AddOptionsWithValidation<DbConnectOptions>();

// ADD DB
var dbOptions = builder.Configuration.GetOptions<DbConnectOptions>();
builder.Services.AddDbContext<DiscountDbContext>(options =>
                 options.UseNpgsql(dbOptions.ConnectionString, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                        .UseSnakeCaseNamingConvention());

// ADD VALIDATOR
builder.Services.AddScoped<IValidator<CreateDiscountCommand>, CreateDiscountValidator>();
builder.Services.AddScoped<IValidator<UpdateDiscountCommand>, UpdateDiscountValidator>();

// ADD GRPC
builder.Services.AddGrpc();

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseRouting();

#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<DiscountService>();
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync(
            "Communication with gRPC endpoints must be made through a gRPC client.");
    });
});

#endregion

app.Run();
