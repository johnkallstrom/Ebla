namespace Ebla.Application.UseCases.Statistics.Queries
{
    public class GetTotalAmountOfBooksQueryHandler : IRequestHandler<GetTotalAmountOfBooksQuery, int>
    {
        private readonly IGenericRepository<Book> _repository;

        public GetTotalAmountOfBooksQueryHandler(IGenericRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(GetTotalAmountOfBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAllAsync();

            return books.Count();
        }
    }
}