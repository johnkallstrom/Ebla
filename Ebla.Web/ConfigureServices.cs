namespace Ebla.Web
{
    public static class ConfigureServices
    {
        public static async Task<IServiceCollection> AddHttpServices(this IServiceCollection services, IConfiguration configuration)
        {
            var uri = new Uri(configuration.GetValue<string>("Ebla.Api:BaseUrl"));

            var serviceProvider = services.BuildServiceProvider();
            ILocalStorageService localStorage = serviceProvider.GetRequiredService<ILocalStorageService>();
            var user = await localStorage.GetItemAsync<CurrentUser>("user");

            services.AddHttpClient<IUserHttpService, UserHttpService>(client =>
            {
                client.BaseAddress = uri;
                client.SetAuthorizationHeader("Bearer", user.Token);
            });
            services.AddHttpClient<IBookHttpService, BookHttpService>(client =>
            {
                client.BaseAddress = uri;
                client.SetAuthorizationHeader("Bearer", user.Token);
            });

            return services;
        }
    }
}