var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IUserHttpService, UserHttpService>(client => client.BaseAddress = new Uri("http://localhost:5121/api/users/"));
builder.Services.AddHttpClient<IBookHttpService, BookHttpService>(client => client.BaseAddress = new Uri("http://localhost:5121/api/books/"));

builder.Services.AddScoped<ICookieStorage, CookieStorage>();

await builder.Build().RunAsync();