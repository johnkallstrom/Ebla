namespace Ebla.Application.Books.Commands
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Response>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
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

                return Response.Success();
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return Response.Failure(errors);
        }
    }
}
