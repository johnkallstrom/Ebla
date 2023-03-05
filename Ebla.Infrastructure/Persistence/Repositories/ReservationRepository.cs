namespace Ebla.Infrastructure.Persistence.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly EblaDbContext _context;

        public ReservationRepository(EblaDbContext context)
        {
            _context = context;
        }

        public Task<Reservation> GetReservationAsync(int reservationId)
        {
            throw new NotImplementedException();
        }

        public async Task<Reservation> GetReservationAsync(Guid userId, int bookId)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(x => x.UserId == userId && x.BookId == bookId);

            return reservation;
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
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return reservations;
        }
    }
}
