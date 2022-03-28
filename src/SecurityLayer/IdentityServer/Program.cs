using IdentityServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryApiScopes(Config.ApiScopes)
    // .AddInMemoryApiResources(Config.ApiResources)
    // .AddInMemoryIdentityResources(Config.IdentityResources)
    // .AddTestUsers(Config.TestUsers)
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseIdentityServer();

app.Run();