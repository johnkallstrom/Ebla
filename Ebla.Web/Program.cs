var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var services = builder.Services;
var configuration = builder.Configuration;

services.AddHttpClient<IUserHttpService, UserHttpService>(client => client.BaseAddress = new Uri(configuration.GetValue<string>("Api:BaseUrl")));
services.AddHttpClient<IBookHttpService, BookHttpService>(client => client.BaseAddress = new Uri(configuration.GetValue<string>("Api:BaseUrl")));
services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();