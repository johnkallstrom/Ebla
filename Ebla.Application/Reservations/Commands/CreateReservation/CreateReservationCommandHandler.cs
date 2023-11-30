using Ebla.Application.Interfaces;

namespace Ebla.Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Reservation> _repository;
        private readonly IIdentityService _identityService;
        private readonly IBookRepository _bookRepository;
        private readonly ILibraryCardRepository _libraryCardRepository;
        private readonly IReservationRepository _reservationRepository;

        public CreateReservationCommandHandler(
            IMapper mapper,
            IGenericRepository<Reservation> repository,
            IIdentityService identityService,
            IBookRepository bookRepository,
            ILibraryCardRepository libraryCardRepository,
            IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _identityService = identityService;
            _bookRepository = bookRepository;
            _libraryCardRepository = libraryCardRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task<Result<int>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
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

                if (!await _libraryCardRepository.HasValidLibraryCard(user.Id))
                {
                    return Result<int>.Failure(new[] { $"No valid library card exists on user with id: {user.Id}" });
                }

                var userReservations = await _reservationRepository.GetReservationListByUserIdAsync(user.Id);
                if (userReservations != null && userReservations.Any(x => x.BookId == book.Id))
                {
                    return Result<int>.Failure(new[] { $"A reservation on this book already exists by user with id: {user.Id}" });
                }

                var reservationToAdd = _mapper.Map<Reservation>(request);
                reservationToAdd.CreatedOn = DateTime.Now;
                reservationToAdd.ExpiresOn = DateTime.Now.AddDays(14);

                await _repository.AddAsync(reservationToAdd);
                await _repository.SaveAsync();

                return Result<int>.Success(reservationToAdd.Id);
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return Result<int>.Failure(errors);
        }
    }
}
