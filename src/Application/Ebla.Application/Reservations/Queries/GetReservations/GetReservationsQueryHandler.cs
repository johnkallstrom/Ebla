namespace Ebla.Application.Reservations.Queries
{
    public class GetReservationsQueryHandler : IRequestHandler<GetReservationsQuery, IEnumerable<ReservationDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _repository;

        public GetReservationsQueryHandler(IMapper mapper, IReservationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<ReservationDto>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _repository.GetAllReservationsAsync();

            return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }
    }
}