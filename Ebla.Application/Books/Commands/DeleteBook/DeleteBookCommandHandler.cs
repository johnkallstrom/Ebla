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
            var validator = new DeleteBookCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.IsValid)
            {
                var book = await _repository.GetByIdAsync(request.Id);

                if (book != null)
                {
                    _repository.Delete(book);
                    await _repository.SaveAsync();
                }
            }

            return Unit.Value;
        }
    }
}
