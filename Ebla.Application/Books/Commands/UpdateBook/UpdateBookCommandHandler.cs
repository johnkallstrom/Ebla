namespace Ebla.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, IResult>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            var validator = new UpdateBookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var bookToUpdate = await _repository.GetByIdAsync(request.Id);
                if (bookToUpdate is null)
                {
                    throw new NotFoundException(nameof(bookToUpdate), request.Id);
                }

                bookToUpdate = _mapper.Map(request, bookToUpdate);
                bookToUpdate.LastModified = DateTime.Now;

                _repository.Update(bookToUpdate);
                await _repository.SaveAsync();

                result.Success();
            }
            else
            {
                result.Failure(validationResult.Errors.Select(x => x.ErrorMessage).ToArray());
            }

            return result;
        }
    }
}
