namespace Ebla.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookCommandResponse>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateBookCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateBookCommandResponse();

            var validator = new CreateBookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var bookToAdd = _mapper.Map<Book>(request);
                bookToAdd.CreatedOn = DateTime.Now;

                await _repository.AddAsync(bookToAdd);
                await _repository.SaveAsync();

                response.Succeeded = true;
            }
            else
            {
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            return response;
        }
    }
}
