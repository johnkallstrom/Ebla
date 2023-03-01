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
            var validator = new UpdateBookCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.IsValid)
            {
                var book = await _repository.GetByIdAsync(request.Id);

                if (book != null)
                {
                    book = _mapper.Map(request, book);

                    _repository.Update(book);
                    await _repository.SaveAsync();
                }
            }

            return Unit.Value;
        }
    }
}
