namespace Ebla.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetById(request.Id);

            return _mapper.Map<BookDto>(book);
        }
    }
}
