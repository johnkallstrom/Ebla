namespace Ebla.Application.Books.Commands
{
    public class DeleteBooksCommandHandler : IRequestHandler<DeleteBooksCommand, Result>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public DeleteBooksCommandHandler(
            IMapper mapper, 
            IBookRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteBooksCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteBooksCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var booksToDelete = await _repository.GetBooksAsync(request.Ids);
                if (booksToDelete is null)
                {
                    throw new NotFoundException(nameof(booksToDelete), request.Ids);
                }

                _repository.DeleteBooks(booksToDelete);
                await _repository.SaveAsync();

                return Result.Success();
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return Result.Failure(errors);
        }
    }
}