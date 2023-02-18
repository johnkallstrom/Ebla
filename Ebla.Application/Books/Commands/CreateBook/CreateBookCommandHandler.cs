namespace Ebla.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Unit>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Pages = request.Pages,
                Published = request.Published,
                IsReserved = request.IsReserved,
                AuthorId = request.AuthorId,
                GenreId = request.GenreId
            };

            await _repository.AddAsync(book);
            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
