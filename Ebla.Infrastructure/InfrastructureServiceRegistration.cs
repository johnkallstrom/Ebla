using Ebla.Application.Interfaces;
using Ebla.Infrastructure.Persistence.Repositories;

namespace Ebla.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EblaDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}