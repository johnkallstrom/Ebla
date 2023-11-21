var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var services = builder.Services;
var configuration = builder.Configuration;

services.AddBlazoredLocalStorage();
await services.AddHttpServices(configuration);
services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProvider>();
services.AddAuthorizationCore();

var host = builder.Build();
await host.RunAsync();