namespace Ebla.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, IResult>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            var validator = new CreateBookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var bookToAdd = _mapper.Map<Book>(request);
                bookToAdd.CreatedOn = DateTime.Now;

                await _repository.AddAsync(bookToAdd);
                await _repository.SaveAsync();

                result.Success();
            }
            else
            {
                var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToArray();
                result.Failure(errors);
            }

            return result;
        }
    }
}
