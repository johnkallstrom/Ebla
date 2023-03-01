namespace Ebla.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, DeleteBookCommandResponse>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public DeleteBookCommandHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeleteBookCommandResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteBookCommandResponse();

            var validator = new DeleteBookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var book = await _repository.GetByIdAsync(request.Id);

                if (book != null)
                {
                    _repository.Delete(book);
                    await _repository.SaveAsync();

                    response.Succeeded = true;
                }
            }
            else
            {
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            return response;
        }
    }
}
