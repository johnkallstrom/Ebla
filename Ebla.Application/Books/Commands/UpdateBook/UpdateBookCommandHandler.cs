namespace Ebla.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, UpdateBookCommandResponse>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateBookCommandResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateBookCommandResponse();

            var validator = new UpdateBookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var bookToUpdate = await _repository.GetByIdAsync(request.Id);

                if (bookToUpdate != null)
                {
                    bookToUpdate = _mapper.Map(request, bookToUpdate);
                    bookToUpdate.LastModified = DateTime.Now;

                    _repository.Update(bookToUpdate);
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
