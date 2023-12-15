﻿namespace Ebla.Persistence.Repositories
{
    public class LibraryCardRepository : ILibraryCardRepository
    {
        private readonly EblaDbContext _context;

        public LibraryCardRepository(EblaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> HasValidLibraryCard(Guid userId)
        {
            return await _context.LibraryCards.AnyAsync(x => x.UserId == userId && x.ExpiresOn >= DateTime.Now);
        }

        public async Task<LibraryCard> GetLibraryCardAsync(Guid userId)
        {
            var libraryCard = await _context.LibraryCards
                .Include(x => x.Library)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            return libraryCard;
        }
    }
}
