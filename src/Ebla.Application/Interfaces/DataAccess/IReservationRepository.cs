namespace Ebla.Application.Interfaces.DataAccess
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<IEnumerable<Reservation>> GetReservationListByUserIdAsync(Guid userId);
        Task<IEnumerable<Reservation>> GetReservationListByBookIdAsync(int bookId);
    }
}
