namespace Ebla.Application.Reservations.Queries.GetReservations
{
    public class GetReservationsQueryHandler : IRequestHandler<GetReservationsQuery, IEnumerable<ReservationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _repository;

        public GetReservationsQueryHandler(IMapper mapper, IReservationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<ReservationResponse>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _repository.GetAllReservationsAsync();

            return _mapper.Map<IEnumerable<ReservationResponse>>(reservations);
        }
    }
}