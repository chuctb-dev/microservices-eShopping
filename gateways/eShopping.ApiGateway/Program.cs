using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.

var env = builder.Environment;
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                      //.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
                      .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services.AddOcelot(builder.Configuration)
            .AddCacheManager(o => o.WithDictionaryHandle());

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello Ocelot");
    });
});
await app.UseOcelot();

#endregion

app.Run();
