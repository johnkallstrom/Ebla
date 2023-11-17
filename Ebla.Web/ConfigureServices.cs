namespace Ebla.Web
{
    public static class ConfigureServices
    {
        public static async Task<IServiceCollection> AddHttpServices(this IServiceCollection services, IConfiguration configuration)
        {
            var uri = new Uri(configuration.GetValue<string>("Ebla.Api:BaseUrl"));

            var serviceProvider = services.BuildServiceProvider();
            ILocalStorageService localStorage = serviceProvider.GetRequiredService<ILocalStorageService>();

            string token = await localStorage.GetItemAsStringAsync(configuration.GetValue<string>("LocalStorage:Token:Key"));

            services.AddHttpClient<IAuthHttpService, AuthHttpService>(client => client.BaseAddress = uri);
            services.AddHttpClient<IUserHttpService, UserHttpService>(client =>
            {
                client.BaseAddress = uri;
                client.SetAuthorizationHeaderWithToken(token);
            });
            services.AddHttpClient<IBookHttpService, BookHttpService>(client =>
            {
                client.BaseAddress = uri;
                client.SetAuthorizationHeaderWithToken(token);
            });

            return services;
        }
    }
}