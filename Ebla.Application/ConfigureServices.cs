namespace Ebla.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            var assemblies = new Assembly[] { Assembly.GetExecutingAssembly(), Assembly.Load("Ebla.Infrastructure") };
            services.AddAutoMapper(assemblies);

            return services;
        }
    }
}