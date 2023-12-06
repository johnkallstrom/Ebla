var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var services = builder.Services;
var configuration = builder.Configuration;

services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(configuration.GetValue<string>("Ebla.Api:BaseUrl")) });
services.AddScoped<IHttpService, HttpService>();
services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProvider>();
services.AddAuthorizationCore();
services.AddBlazoredLocalStorage();
services.AddMudServices();

await builder.Build().RunAsync();