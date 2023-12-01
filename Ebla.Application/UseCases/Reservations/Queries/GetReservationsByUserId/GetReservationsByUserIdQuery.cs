namespace Ebla.Application.UseCases.Reservations.Queries
{
    public class GetReservationsByUserIdQuery : IRequest<IEnumerable<ReservationResponse>>
    {
        public Guid UserId { get; set; }
    }
}
