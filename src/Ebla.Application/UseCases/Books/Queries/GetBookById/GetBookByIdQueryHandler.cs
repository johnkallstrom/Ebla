namespace Ebla.Application.UseCases.Books.Queries
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetBookByIdAsync(request.Id);

            if (book is null)
            {
                throw new NotFoundException(nameof(book), request.Id);
            }

            return _mapper.Map<BookDto>(book);
        }
    }
}
