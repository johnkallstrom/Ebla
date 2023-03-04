﻿namespace Ebla.Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, CreateReservationCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Reservation> _repository;
        private readonly IIdentityService _identityService;
        private readonly IBookRepository _bookRepository;
        private readonly ILibraryCardRepository _libraryCardRepository;
        private readonly ILoanRepository _loanRepository;

        public CreateReservationCommandHandler(
            IMapper mapper,
            IGenericRepository<Reservation> repository,
            IIdentityService identityService,
            IBookRepository bookRepository,
            ILibraryCardRepository libraryCardRepository,
            ILoanRepository loanRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _identityService = identityService;
            _bookRepository = bookRepository;
            _libraryCardRepository = libraryCardRepository;
            _loanRepository = loanRepository;
        }

        public async Task<CreateReservationCommandResponse> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateReservationCommandResponse();

            var validator = new CreateReservationCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                // Check if user exists
                var user = await _identityService.GetUserAsync(request.UserId);
                if (user == null)
                {
                    response.Errors.Add($"No user with id: {request.UserId} could be found");
                    return response;
                }

                // Check if book exists
                var book = await _bookRepository.GetBookByIdAsync(request.BookId);
                if (book == null)
                {
                    response.Errors.Add($"No book with id: {request.BookId} could be found");
                    return response;
                }

                // Check that user has a valid library card
                var libraryCard = await _libraryCardRepository.GetLibraryCardByUserIdAsync(user.Id);
                if (libraryCard == null || libraryCard.Expires < DateTime.Now)
                {
                    response.Errors.Add($"The user with id: {user.Id} does not have a valid library card");
                    return response;
                }

                // Check if book is reserved
                if (book.IsReserved)
                {
                    response.Errors.Add($"The book with id: {book.Id} is reserved");
                    return response;
                }

                // Check if book is loaned
                var loan = await _loanRepository.GetLoanByBookIdAsync(book.Id);
                if (loan != null && loan.Returned == null)
                {
                    response.Errors.Add($"The book with id: {book.Id} is loaned");
                    return response;
                }

                var reservationToAdd = _mapper.Map<Reservation>(request);
                reservationToAdd.CreatedOn = DateTime.Now;

                await _repository.AddAsync(reservationToAdd);
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
