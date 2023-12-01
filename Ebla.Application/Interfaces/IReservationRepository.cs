namespace Ebla.Application.Interfaces
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Domain.Entities.Reservation>> GetAllReservationsAsync();
        Task<IEnumerable<Domain.Entities.Reservation>> GetReservationListByUserIdAsync(Guid userId);
        Task<IEnumerable<Domain.Entities.Reservation>> GetReservationListByBookIdAsync(int bookId);
    }
}
