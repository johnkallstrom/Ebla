var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var services = builder.Services;
var configuration = builder.Configuration;

services.AddHttpServices(configuration);
services.AddBlazoredLocalStorage();
services.AddAuthorizationCore();

await builder.Build().RunAsync();