namespace Ebla.Application.Loans.Commands.CreateLoan
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, IResult>
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

        public async Task<IResult> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

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
                    result.Failure(new[] { "No valid library card could be found on this user" });
                    return result;
                }

                var loan = await _loanRepository.GetLoanByBookIdAsync(book.Id);
                if (loan != null)
                {
                    result.Failure(new[] { "A loan already exists on this book, its not available" });
                    return result;
                }

                // If user has 5 or more existing loans, no more can be created
                var userLoans = await _loanRepository.GetLoanListByUserIdAsync(user.Id);
                if (userLoans != null && userLoans.Count() >= 5)
                {
                    result.Failure(new[] { $"The user with id: {user.Id} have reached maximum amount of loans" });
                    return result;
                }

                var loanToAdd = _mapper.Map<Loan>(request);
                loanToAdd.CreatedOn = DateTime.Now;

                // If book has 2 or more reservations the loan time is 14 days, otherwise 1 month
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
