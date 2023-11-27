namespace Ebla.Infrastructure.Persistence.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly EblaDbContext _context;

        public LibraryRepository(EblaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Library>> GetAllLibrariesAsync()
        {
            var libraries = await _context.Libraries.ToListAsync();

            return libraries;
        }

        public async Task<Library> GetLibraryByIdAsync(int libraryId)
        {
            var library = await _context.Libraries
                .Include(x => x.LibraryCards)
                .FirstOrDefaultAsync(x => x.Id == libraryId);

            return library;
        }
    }
}
