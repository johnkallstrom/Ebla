namespace Ebla.Application.Common.Interfaces
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetReservationsByUserId(Guid userId);
    }
}
