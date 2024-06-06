using eShopping.MassTransit;
using eShopping.Ordering.Api.Consumers;
using eShopping.Ordering.Application;
using eShopping.Ordering.Core;
using eShopping.Ordering.Core.AppSettings;
using eShopping.Ordering.Infrastructure;
using eShopping.Ordering.Infrastructure.Data.Extensions;
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
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);

// ADD MASSTRANSIT
var masstransitOptions = builder.Configuration.GetOptions<EventBusConnectOptions>();
builder.Services.AddMassTransitLayer(config =>
{
    //Mark this as consumer
    config.AddConsumer<BasketOrderingConsumer>();
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(masstransitOptions.HostAddress);
        cfg.ReceiveEndpoint(RabbitMQConsts.BasketCheckoutEventQueueName, c =>
        {
            c.ConfigureConsumer<BasketOrderingConsumer>(ctx);
        });
    });
});

// ADD SWAGGER
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ordering Api", Version = "v1" });
});

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ordering.API v1"));
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();

#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/ordering-health", new HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});

#endregion

app.Run();