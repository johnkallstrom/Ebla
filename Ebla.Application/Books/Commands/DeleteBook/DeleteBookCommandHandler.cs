namespace Ebla.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public DeleteBookCommandHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.Id);
            
            _repository.Delete(book);
            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
