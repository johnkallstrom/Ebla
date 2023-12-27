namespace Ebla.Persistence.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly EblaDbContext _context;

        public LibraryRepository(EblaDbContext context)
        {
            _context = context;
        }

        public async Task<Library> GetLibraryByIdAsync(int libraryId)
        {
            var library = await _context.Libraries.FirstOrDefaultAsync(x => x.Id == libraryId);

            return library;
        }
    }
}