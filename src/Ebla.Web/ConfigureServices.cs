namespace Ebla.Web
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddHttpServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IHttpService<>), typeof(HttpService<>));
            services.AddScoped<IAuthorHttpService, AuthorHttpService>();
            services.AddScoped<IBookHttpService, BookHttpService>();
            services.AddScoped<IGenreHttpService, GenreHttpService>();
            services.AddScoped<ILibraryHttpService, LibraryHttpService>();

            return services;
        }
    }
}
