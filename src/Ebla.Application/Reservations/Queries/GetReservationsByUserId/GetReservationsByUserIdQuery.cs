namespace Ebla.Application.Reservations.Queries
{
    public class GetReservationsByUserIdQuery : IRequest<IEnumerable<ReservationDto>>
    {
        public Guid UserId { get; set; }
    }
}
