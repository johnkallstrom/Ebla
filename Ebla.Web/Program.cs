var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var services = builder.Services;
var configuration = builder.Configuration;

services.AddBlazoredLocalStorage();
services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(configuration.GetValue<string>("Ebla.Api:BaseUrl")) });
services.AddScoped<IHttpService, HttpService>();
services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProvider>();
services.AddAuthorizationCore();

// To be removed
await services.AddHttpServices(configuration);

await builder.Build().RunAsync();