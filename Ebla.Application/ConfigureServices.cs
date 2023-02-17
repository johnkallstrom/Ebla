using Microsoft.Extensions.DependencyInjection;

namespace Ebla.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}