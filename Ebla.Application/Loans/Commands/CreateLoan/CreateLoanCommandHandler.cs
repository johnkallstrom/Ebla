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

                var libraryCard = await _libraryCardRepository.GetLibraryCardAsync(user.Id);
                if (libraryCard == null || libraryCard.ExpiresOn < DateTime.Now)
                {
                    return Result<int>.Failure(new[] { "Invalid library card" });
                }

                var loan = await _loanRepository.GetLoanByBookIdAsync(book.Id);
                if (loan != null)
                {
                    return Result<int>.Failure(new[] { "Loan already exists" });
                }

                var userLoans = await _loanRepository.GetLoanListByUserIdAsync(user.Id);
                if (userLoans != null && userLoans.Count() >= 5)
                {
                    return Result<int>.Failure(new[] { "User has reached maximum amount of loans" });
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
