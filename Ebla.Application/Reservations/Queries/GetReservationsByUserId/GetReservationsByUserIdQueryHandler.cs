namespace Ebla.Application.Reservations.Queries.GetReservationsByUserId
{
    public class GetReservationsByUserIdQueryHandler : IRequestHandler<GetReservationsByUserIdQuery, IEnumerable<ReservationDto>>
    {
        public Task<IEnumerable<ReservationDto>> Handle(GetReservationsByUserIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
