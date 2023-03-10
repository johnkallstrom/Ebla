namespace Ebla.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EblaDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ILibraryCardRepository, LibraryCardRepository>();
            services.AddTransient<ILoanRepository, LoanRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<EblaDbContext>();

            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IJwtProvider, JwtProvider>();

            return services;
        }
    }
}