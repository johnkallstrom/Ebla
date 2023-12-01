namespace Ebla.Application.UseCases.Reservation.Queries
{
    public class GetReservationsByUserIdQuery : IRequest<IEnumerable<ReservationResponse>>
    {
        public Guid UserId { get; set; }
    }
}
