namespace Ebla.Infrastructure.Persistence.Repositories
{
    public class LibraryCardRepository : ILibraryCardRepository
    {
        private readonly EblaDbContext _context;

        public LibraryCardRepository(EblaDbContext context)
        {
            _context = context;
        }

        public async Task<LibraryCard> GetLibraryCardAsync(Guid userId)
        {
            var libraryCard = await _context.LibraryCards.FirstOrDefaultAsync(x => x.UserId == userId);
            if (libraryCard is null)
            {
                throw new NotFoundException(nameof(libraryCard), userId);
            }

            return libraryCard;
        }
    }
}
