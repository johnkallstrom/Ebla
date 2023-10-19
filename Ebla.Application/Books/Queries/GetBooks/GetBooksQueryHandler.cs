namespace Ebla.Application.Books.Queries.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookSlimDto>>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookSlimDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAllBooksAsync();

            return _mapper.Map<IEnumerable<BookSlimDto>>(books);
        }
    }
}
