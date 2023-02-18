namespace Ebla.Application.Books.Queries.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAll();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
}
