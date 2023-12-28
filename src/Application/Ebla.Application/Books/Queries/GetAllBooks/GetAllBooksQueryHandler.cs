namespace Ebla.Application.Books.Queries
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookSlimDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _repository;

        public GetAllBooksQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookSlimDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAllBooksAsync();

            return _mapper.Map<IEnumerable<BookSlimDto>>(books);
        }
    }
}