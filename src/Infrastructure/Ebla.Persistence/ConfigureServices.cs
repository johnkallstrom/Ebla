namespace Ebla.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("Database:ConnectionString");
            services.AddDbContext<EblaDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ILibraryCardRepository, LibraryCardRepository>();
            services.AddTransient<ILoanRepository, LoanRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<ILibraryRepository, LibraryRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<EblaDbContext>();

            return services;
        }
    }
}
