namespace Ebla.Application.Loans.Commands.CreateLoan
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, CreateLoanCommandResponse>
    {
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
            ILoanRepository loanRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _identityService = identityService;
            _bookRepository = bookRepository;
            _libraryCardRepository = libraryCardRepository;
            _loanRepository = loanRepository;
        }

        public async Task<CreateLoanCommandResponse> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateLoanCommandResponse();

            var validator = new CreateLoanCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var user = await _identityService.GetUserAsync(request.UserId);
                if (user == null)
                {
                    response.Errors.Add($"No user with id: {request.UserId} could be found");
                    return response;
                }

                var book = await _bookRepository.GetBookByIdAsync(request.BookId);
                if (book == null)
                {
                    response.Errors.Add($"No book with id: {request.BookId} could be found");
                    return response;
                }

                var libraryCard = await _libraryCardRepository.GetLibraryCardAsync(user.Id);
                if (libraryCard == null || libraryCard.ExpiresOn < DateTime.Now)
                {
                    response.Errors.Add($"No valid library card could be found on this user");
                    return response;
                }

                var loan = await _loanRepository.GetLoanByBookIdAsync(book.Id);
                if (loan != null)
                {
                    response.Errors.Add($"A loan already exists on this book, its not available");
                    return response;
                }

                var loanToAdd = _mapper.Map<Loan>(request);
                loanToAdd.CreatedOn = DateTime.Now;
                loanToAdd.DueDate = DateTime.Now.AddMonths(1);

                await _repository.AddAsync(loanToAdd);
                await _repository.SaveAsync();

                response.Succeeded = true;
            }
            else
            {
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            return response;
        }
    }
}
