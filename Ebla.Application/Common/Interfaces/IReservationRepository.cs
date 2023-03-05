namespace Ebla.Application.Common.Interfaces
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetReservationListByUserIdAsync(Guid userId);
        Task<IEnumerable<Reservation>> GetReservationListByBookIdAsync(int bookId);
        Task<Reservation> GetReservationAsync(int reservationId);
        Task<Reservation> GetReservationAsync(Guid userId, int bookId);
    }
}
