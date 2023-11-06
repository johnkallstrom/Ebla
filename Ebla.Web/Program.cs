var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IUserHttpService, UserHttpService>(client => client.BaseAddress = new Uri("http://localhost:5121"));
builder.Services.AddHttpClient<IBookHttpService, BookHttpService>(client => client.BaseAddress = new Uri("http://localhost:5121"));

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();