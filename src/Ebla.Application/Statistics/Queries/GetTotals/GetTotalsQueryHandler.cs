namespace Ebla.Application.Statistics.Queries
{
    public class GetTotalsQueryHandler : IRequestHandler<GetTotalsQuery, Dictionary<string, int>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IIdentityService _identityService;
        private readonly ILoanRepository _loanRepository;
        private readonly IReservationRepository _reservationRepository;

        public GetTotalsQueryHandler(
            IBookRepository bookRepository, 
            IIdentityService identityService, 
            ILoanRepository loanRepository, 
            IReservationRepository reservationRepository)
        {
            _bookRepository = bookRepository;
            _identityService = identityService;
            _loanRepository = loanRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task<Dictionary<string, int>> Handle(GetTotalsQuery request, CancellationToken cancellationToken)
        {
            int books = await _bookRepository.GetTotalBooksAsync();
            int users = await _identityService.GetTotalUsersAsync();
            int loans = await _loanRepository.GetTotalLoansAsync();
            int reservations = await _reservationRepository.GetTotalReservationsAsync();

            var result = new Dictionary<string, int>
            {
                { "books", books },
                { "users", users },
                { "loans", loans },
                { "reservations", reservations },
            };

            return result;
        }
    }
}