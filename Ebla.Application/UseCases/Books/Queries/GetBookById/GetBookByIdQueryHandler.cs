namespace Ebla.Application.UseCases.Books.Queries
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookResponse>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetBookByIdAsync(request.Id);

            if (book is null)
            {
                throw new NotFoundException(nameof(book), request.Id);
            }

            return _mapper.Map<BookResponse>(book);
        }
    }
}
