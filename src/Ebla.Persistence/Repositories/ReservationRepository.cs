namespace Ebla.Persistence.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly EblaDbContext _context;

        public ReservationRepository(EblaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            var reservations = await _context.Reservations
                .Include(x => x.Book)
                    .ThenInclude(x => x.Author)
                .Include(x => x.Book)
                    .ThenInclude(x => x.Genre)
                .ToListAsync();

            return reservations;
        }

        public async Task<IEnumerable<Reservation>> GetReservationListByBookIdAsync(int bookId)
        {
            var reservations = await _context.Reservations
                .Include(x => x.Book)
                .Where(x => x.BookId == bookId)
                .ToListAsync();

            return reservations;
        }

        public async Task<IEnumerable<Reservation>> GetReservationListByUserIdAsync(Guid userId)
        {
            var reservations = await _context.Reservations
                .Include(x => x.Book)
                    .ThenInclude(x => x.Author)
                .Include(x => x.Book)
                    .ThenInclude(x => x.Genre)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return reservations;
        }

        public async Task<int> GetTotalReservationsAsync() => await _context.Reservations.CountAsync();
    }
}
