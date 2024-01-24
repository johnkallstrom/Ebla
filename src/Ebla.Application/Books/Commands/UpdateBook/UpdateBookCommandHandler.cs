namespace Ebla.Application.Books.Commands
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Result>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var bookToUpdate = await _repository.Get(request.Id);
                if (bookToUpdate is null)
                {
                    throw new NotFoundException(nameof(bookToUpdate), request.Id);
                }

                bookToUpdate = _mapper.Map(request, bookToUpdate);
                bookToUpdate.LastModified = DateTime.Now;

                _repository.Update(bookToUpdate);
                await _repository.SaveAsync();

                return Result.Success();
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return Result.Failure(errors);
        }
    }
}
