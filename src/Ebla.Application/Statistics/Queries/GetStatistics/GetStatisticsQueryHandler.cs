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
                var genreStatisticsData = CalculateGenrePercentages(genres, totalBooks);

                var statistics = new StatisticsDto
                {
                    TotalBooks = totalBooks,
                    TotalUsers = totalUsers,
                    TotalLoans = totalLoans,
                    TotalReservations = totalReservations,
                    GenreLabels = genreStatisticsData.Keys.ToArray(),
                    GenrePercentages = genreStatisticsData.Values.ToArray()
                };

                return Response<StatisticsDto>.Success(statistics);
            }
            catch (Exception ex)
            {
                return Response<StatisticsDto>.Failure([ex.Message]);
            }
        }

        private Dictionary<string, double> CalculateGenrePercentages(IEnumerable<Genre> genres, int totalBooks)
        {
            IEnumerable<IGrouping<string, Genre>> groupings = genres.GroupBy(genre => genre.Name).AsEnumerable();

            var flattened = groupings.SelectMany(group => group.Where(genre => genre.Books != null).Select(genre => new { Genre = group.Key, Books = genre.Books.Count()}))
                .OrderByDescending(x => x.Books)
                .ToList();

            var result = new Dictionary<string, double>();
            foreach (var item in flattened)
            {
                double percentage = Math.Round((double)item.Books / totalBooks * 100, 2);
                result.Add(item.Genre, percentage);
            }

            return result;
        }
    }
}