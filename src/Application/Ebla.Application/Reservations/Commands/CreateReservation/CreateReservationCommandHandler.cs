namespace Ebla.Application.Reservations.Commands
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Reservation> _repository;
        private readonly IIdentityService _identityService;
        private readonly IBookRepository _bookRepository;
        private readonly IReservationRepository _reservationRepository;

        public CreateReservationCommandHandler(
            IMapper mapper,
            IGenericRepository<Reservation> repository,
            IIdentityService identityService,
            IBookRepository bookRepository,
            IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _identityService = identityService;
            _bookRepository = bookRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task<Response<int>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateReservationCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var user = await _identityService.GetUserAsync(request.UserId);
                if (user is null)
                {
                    throw new NotFoundException(nameof(user), request.UserId);
                }

                var book = await _bookRepository.GetBookByIdAsync(request.BookId);
                if (book is null)
                {
                    throw new NotFoundException(nameof(book), request.BookId);
                }

                var userReservations = await _reservationRepository.GetReservationListByUserIdAsync(user.Id);
                if (userReservations != null && userReservations.Any(x => x.BookId == book.Id))
                {
                    return Response<int>.Failure(new[] { $"A reservation on this book already exists by user with id: {user.Id}" });
                }

                var reservationToAdd = _mapper.Map<Reservation>(request);
                reservationToAdd.CreatedOn = DateTime.Now;
                reservationToAdd.ExpiresOn = DateTime.Now.AddDays(14);

                await _repository.AddAsync(reservationToAdd);
                await _repository.SaveAsync();

                return Response<int>.Success(reservationToAdd.Id);
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return Response<int>.Failure(errors);
        }
    }
}
