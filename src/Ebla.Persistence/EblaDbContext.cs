namespace Ebla.Persistence
{
    public class EblaDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public EblaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookLibrary> BookLibraries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookLibraryConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new LibraryConfiguration());
            modelBuilder.ApplyConfiguration(new LibraryCardConfiguration());
            modelBuilder.ApplyConfiguration(new LoanConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyIdentityConfigurations();
        }
    }
}