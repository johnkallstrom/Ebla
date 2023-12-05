namespace Ebla.Application.UseCases.Reservations.Queries
{
    public class GetReservationsByUserIdQuery : IRequest<IEnumerable<ReservationDto>>
    {
        public Guid UserId { get; set; }
    }
}
