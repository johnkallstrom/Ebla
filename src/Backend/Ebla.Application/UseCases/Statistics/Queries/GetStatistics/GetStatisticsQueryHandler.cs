namespace Ebla.Application.UseCases.Statistics.Queries
{
    public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery, StatisticsDto>
    {
        private readonly IBookRepository _bookRepository;

        public GetStatisticsQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<StatisticsDto> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
        {
            int booksAmount = await _bookRepository.GetTotalBookCountAsync();

            return new StatisticsDto(totalAmountOfBooks: booksAmount);
        }
    }
}