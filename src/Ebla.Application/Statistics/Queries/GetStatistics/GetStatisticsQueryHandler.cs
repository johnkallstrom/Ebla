namespace Ebla.Application.Statistics.Queries
{
    public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery, Response<StatisticsDto>>
    {
        private readonly IIdentityService _identityService;
        private readonly ILoanRepository _loanRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IBookRepository _bookRepository;

        public GetStatisticsQueryHandler(
            IBookRepository bookRepository,
            IGenreRepository genreRepository,
            ILoanRepository loanRepository,
            IReservationRepository reservationRepository,
            IIdentityService identityService)
        {
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
            _loanRepository = loanRepository;
            _reservationRepository = reservationRepository;
            _identityService = identityService;
        }

        public async Task<Response<StatisticsDto>> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                int totalBooks = await _bookRepository.GetTotalBooksAsync();
                int totalUsers = await _identityService.GetTotalUsersAsync();
                int totalLoans = await _loanRepository.GetTotalLoansAsync();
                int totalReservations = await _reservationRepository.GetTotalReservationsAsync();
                var genres = await _genreRepository.GetAllGenresAsync();

                var data = GetGenreStatisticsData(genres, totalBooks);
                var genreLabels = data.Keys.ToArray();
                var genrePercentages = data.Values.ToArray();

                var statistics = new StatisticsDto
                {
                    TotalBooks = totalBooks,
                    TotalUsers = totalUsers,
                    TotalLoans = totalLoans,
                    TotalReservations = totalReservations,
                    GenreLabels = genreLabels,
                    GenrePercentages = genrePercentages
                };

                return Response<StatisticsDto>.Success(statistics);
            }
            catch (Exception ex)
            {
                return Response<StatisticsDto>.Failure([ex.Message]);
            }
        }

        private Dictionary<string, double> GetGenreStatisticsData(IEnumerable<Genre> genres, int totalBooks)
        {
            // Group each genre by name
            IEnumerable<IGrouping<string, Genre>> groups = genres.GroupBy(genre => genre.Name).AsEnumerable();

            // Create anonymous list containing genre name and book amount
            var flattened = groups
                .SelectMany(group => group.Where(genre => genre.Books != null).Select(genre => new
                {
                    Genre = group.Key,
                    Books = genre.Books.Count()
                })).OrderByDescending(x => x.Books).ToList();

            // Calculate percentage from the amount of books each genre has and the total books stored in db
            var data = new Dictionary<string, double>();
            foreach (var item in flattened)
            {
                double percentage = Math.Round((double)item.Books / totalBooks * 100, 2);
                data.Add(item.Genre, percentage);
            }

            return data;
        }
    }
}