namespace Ebla.Web
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddHttpServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IUserHttpService, UserHttpService>(client => client.BaseAddress = new Uri(configuration.GetValue<string>("Ebla.Api:BaseUrl")));
            services.AddHttpClient<IBookHttpService, BookHttpService>(client => client.BaseAddress = new Uri(configuration.GetValue<string>("Ebla.Api:BaseUrl")));

            return services;
        }
    }
}
