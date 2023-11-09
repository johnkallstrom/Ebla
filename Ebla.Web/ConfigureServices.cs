namespace Ebla.Web
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddHttpServices(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration.GetValue<string>("Ebla.Api:BaseUrl");

            services.AddHttpClient<IUserHttpService, UserHttpService>(client => client.BaseAddress = new Uri(url));
            services.AddHttpClient<IBookHttpService, BookHttpService>(client => client.BaseAddress = new Uri(url));

            return services;
        }
    }
}
