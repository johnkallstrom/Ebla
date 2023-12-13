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
            var genreData = _genreRepository.GetStatisticsData();

            return new StatisticsDto(totalBooks, genreData);
        }
    }
}