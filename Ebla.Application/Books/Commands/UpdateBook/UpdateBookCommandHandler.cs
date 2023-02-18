namespace Ebla.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.Id);

            if (book != null)
            {
                book.Title = request.Title;
                book.Pages = request.Pages;
                book.Published = request.Published;
                book.IsReserved = request.IsReserved;
                book.AuthorId = request.AuthorId;
                book.GenreId = request.GenreId;
            }

            _repository.Update(book);
            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
