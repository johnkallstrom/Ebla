﻿namespace Ebla.Infrastructure.Persistence.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly EblaDbContext _context;

        public ReservationRepository(EblaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByUserId(Guid userId)
        {
            var reservations = await _context.Reservations
                .Include(x => x.Book)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return reservations;
        }
    }
}
