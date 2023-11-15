namespace Ebla.Web
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddHttpServices(this IServiceCollection services, IConfiguration configuration)
        {
            var uri = new Uri(configuration.GetValue<string>("Ebla.Api:BaseUrl"));

            services.AddHttpClient<IUserHttpService, UserHttpService>(client => client.BaseAddress = uri);
            services.AddHttpClient<IBookHttpService, BookHttpService>(client => client.BaseAddress = uri);

            return services;
        }
    }
}