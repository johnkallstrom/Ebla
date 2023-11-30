using Ebla.Application.Interfaces;

namespace Ebla.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IIdentityService, IdentityService>();

            services.ConfigureOptions<JwtOptionsConfiguration>();
            services.AddTransient<IJwtProvider, JwtProvider>();

            return services;
        }
    }
}