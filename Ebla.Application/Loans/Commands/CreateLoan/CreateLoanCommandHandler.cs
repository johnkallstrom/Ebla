namespace Ebla.Application.Loans.Commands.CreateLoan
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Result<int>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly ILibraryCardRepository _libraryCardRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Loan> _repository;

        public CreateLoanCommandHandler(
            IGenericRepository<Loan> repository,
            IMapper mapper,
            IIdentityService identityService,
            IBookRepository bookRepository,
            ILibraryCardRepository libraryCardRepository,
            ILoanRepository loanRepository,
            IReservationRepository reservationRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _identityService = identityService;
            _bookRepository = bookRepository;
            _libraryCardRepository = libraryCardRepository;
            _loanRepository = loanRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task<Result<int>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLoanCommandValidator();
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

                if (!await _libraryCardRepository.CheckValidLibraryCardExists(user.Id))
                {
                    return Result<int>.Failure(new[] { $"No valid library card exists on user with id: {user.Id}" });
                }

                var activeLoans = await _loanRepository.GetActiveLoansByBookIdAsync(book.Id);
                if (activeLoans != null && activeLoans.Count() > 0)
                {
                    return Result<int>.Failure(new[] { $"There is active loans that has not yet been returned on book with id {book.Id}" });
                }

                var activeUserLoans = await _loanRepository.GetActiveLoansByUserIdAsync(user.Id);
                if (activeUserLoans != null && activeUserLoans.Count() >= 5)
                {
                    return Result<int>.Failure(new[] { $"To many active loans on user with id: {user.Id}" });
                }

                var loanToAdd = _mapper.Map<Loan>(request);
                loanToAdd.CreatedOn = DateTime.Now;

                var reservations = await _reservationRepository.GetReservationListByBookIdAsync(book.Id);
                if (reservations != null && reservations.Count() >= 2)
                {
                    loanToAdd.DueDate = DateTime.Now.AddDays(14);
                }
                else
                {
                    loanToAdd.DueDate = DateTime.Now.AddMonths(1);
                }

                await _repository.AddAsync(loanToAdd);
                await _repository.SaveAsync();

                return Result<int>.Success(loanToAdd.Id);
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return Result<int>.Failure(errors);
        }
    }
}
