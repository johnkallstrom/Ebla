namespace Ebla.Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, IResult<int>>
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

        public async Task<IResult<int>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<int>();

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

                var libraryCard = await _libraryCardRepository.GetLibraryCardAsync(user.Id);
                if (libraryCard == null || libraryCard.ExpiresOn < DateTime.Now)
                {
                    result.Failure(new[] { "No valid library card could be found on this user" });
                    return result;
                }

                var reservation = await _reservationRepository.GetReservationAsync(user.Id, book.Id);
                if (reservation != null && reservation.ExpiresOn > DateTime.Now)
                {
                    result.Failure(new[] { "A reservation already exists" });
                    return result;
                }

                var reservationToAdd = _mapper.Map<Reservation>(request);
                reservationToAdd.CreatedOn = DateTime.Now;
                reservationToAdd.ExpiresOn = DateTime.Now.AddDays(14);

                await _repository.AddAsync(reservationToAdd);
                await _repository.SaveAsync();

                result.Value = reservationToAdd.Id;
                result.Success();
            }
            else
            {
                result.Failure(validationResult.Errors.Select(x => x.ErrorMessage).ToArray());
            }

            return result;
        }
    }
}
