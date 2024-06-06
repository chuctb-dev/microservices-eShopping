using eShopping.Basket.Api.Consumers;
using eShopping.Basket.Application;
using eShopping.Basket.Core;
using eShopping.Basket.Core.AppSettings;
using eShopping.Basket.Infrastructure;
using eShopping.MassTransit;
using eShopping.SharedKernel.Extensions;
using eShopping.SharedKernel.Middlewares;
using HealthChecks.UI.Client;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApiVersioning();

// ADD LAYER
builder.Services.AddCoreLayer();
builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddInfrastructureLayer(builder.Configuration);

// ADD MASSTRANSIT
var masstransitOptions = builder.Configuration.GetOptions<EventBusConnectOptions>();
builder.Services.AddMassTransitLayer(config =>
{
    config.AddConsumer<OrderCreatedConsumer>();
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(masstransitOptions.HostAddress);
        cfg.ReceiveEndpoint(RabbitMQConsts.OrderCreatedEventQueueName, c =>
        {
            c.ConfigureConsumer<OrderCreatedConsumer>(ctx);
        });
    });
});

// ADD SWAGGER
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket Api", Version = "v1" });
});

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket.API v1"));
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();

#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/basket-health", new HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});

#endregion

app.Run();
