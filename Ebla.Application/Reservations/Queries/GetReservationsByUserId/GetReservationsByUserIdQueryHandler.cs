namespace Ebla.Application.Reservations.Queries.GetReservationsByUserId
{
    public class GetReservationsByUserIdQueryHandler : IRequestHandler<GetReservationsByUserIdQuery, IEnumerable<ReservationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _repository;

        public GetReservationsByUserIdQueryHandler(IReservationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservationResponse>> Handle(GetReservationsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _repository.GetReservationListByUserIdAsync(request.UserId);

            return _mapper.Map<IEnumerable<ReservationResponse>>(reservations);
        }
    }
}
