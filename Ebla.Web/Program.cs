var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var services = builder.Services;
var configuration = builder.Configuration;

services.AddBlazoredLocalStorage();
services.AddScoped<IAuthenticationService, AuthenticationService>();
await services.AddHttpServices(configuration);

var host = builder.Build();

var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
await authenticationService.InitializeAsync();

await host.RunAsync();