namespace Ebla.Infrastructure.Persistence.Repositories
{
    public class LibraryCardRepository : ILibraryCardRepository
    {
        private readonly EblaDbContext _context;

        public LibraryCardRepository(EblaDbContext context)
        {
            _context = context;
        }

        public async Task<LibraryCard> GetLibraryCardByUserIdAsync(Guid userId)
        {
            var libraryCard = await _context.LibraryCards.FirstOrDefaultAsync(x => x.UserId == userId);

            return libraryCard;
        }

        public async Task<bool> LibraryCardExists(Guid userId)
        {
            return await _context.LibraryCards.AnyAsync(x => x.UserId == userId);
        }
    }
}
