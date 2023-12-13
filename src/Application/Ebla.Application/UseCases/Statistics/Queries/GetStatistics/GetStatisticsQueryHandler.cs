namespace Ebla.Application.UseCases.Statistics.Queries
{
    public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery, StatisticsDto>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IBookRepository _bookRepository;

        public GetStatisticsQueryHandler(
            IBookRepository bookRepository, 
            IGenreRepository genreRepository)
        {
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
        }

        public async Task<StatisticsDto> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
        {
            int totalBooks = await _bookRepository.GetTotalBooksAsync();

            var data = _genreRepository.GetStatisticsData();
            var genreLabels = data.Keys.ToArray();
            var genrePercentages = data.Values.ToArray();

            var statistics = new StatisticsDto
            {
                TotalBooks = totalBooks,
                GenreLabels = genreLabels,
                GenrePercentages = genrePercentages
            };

            return statistics;
        }
    }
}