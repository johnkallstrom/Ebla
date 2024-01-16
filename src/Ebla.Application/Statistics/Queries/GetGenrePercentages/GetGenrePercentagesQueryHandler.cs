namespace Ebla.Application.Statistics.Queries
{
    public class GetGenrePercentagesQueryHandler : IRequestHandler<GetGenrePercentagesQuery, Dictionary<string, double>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGenericRepository<Genre> _repository;

        public GetGenrePercentagesQueryHandler(
            IGenericRepository<Genre> repository, 
            IBookRepository bookRepository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
        }

        public async Task<Dictionary<string, double>> Handle(GetGenrePercentagesQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetGenrePercentagesQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var genres = await _repository.GetAllAsync();
                var totalBooks = await _bookRepository.GetTotalBooksAsync();

                var groupings = genres.GroupBy(genre => genre.Name).AsEnumerable();

                var flattened = groupings
                    .SelectMany(group => group.Where(genre => genre.Books != null)
                    .Select(genre => new
                    {
                        Genre = group.Key,
                        Books = genre.Books.Count()
                    })).Take(request.Count).OrderByDescending(x => x.Books).ToList();

                var result = new Dictionary<string, double>();
                foreach (var item in flattened)
                {
                    double percentage = Math.Round((double)item.Books / totalBooks * 100, 2);
                    result.Add(item.Genre, percentage);
                }

                return result;
            }

            return new Dictionary<string, double>();
        }
    }
}