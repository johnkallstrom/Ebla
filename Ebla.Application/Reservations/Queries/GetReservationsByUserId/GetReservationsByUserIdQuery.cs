namespace Ebla.Application.Reservations.Queries.GetReservationsByUserId
{
    public class GetReservationsByUserIdQuery : IRequest<IEnumerable<ReservationDto>>
    {
        public Guid UserId { get; set; }
    }
}
