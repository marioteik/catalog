using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

IConfiguration ocelotConfiguration = new ConfigurationBuilder()
    .AddJsonFile($"ocelot.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
    .Build();

builder.Services.AddOcelot(ocelotConfiguration).AddCacheManager(c => c.WithDictionaryHandle());
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

app.UseOcelot();

app.Run();