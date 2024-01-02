
namespace Ebla.Persistence.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly EblaDbContext _context;

        public GenreRepository(EblaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            var genres = await _context.Genres.ToListAsync();

            return genres;
        }
    }
}