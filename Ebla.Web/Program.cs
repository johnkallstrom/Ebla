var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IUserHttpService, UserHttpService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5121");
});

builder.Services.AddScoped<ICookieStorage, CookieStorage>();

await builder.Build().RunAsync();