namespace Ebla.Application.Reservations.Queries.GetReservationsByUserId
{
    public class GetReservationsByUserIdQuery : IRequest<IEnumerable<ReservationResponse>>
    {
        public Guid UserId { get; set; }
    }
}
