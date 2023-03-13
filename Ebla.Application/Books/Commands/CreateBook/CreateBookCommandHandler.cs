namespace Ebla.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, IResult<int>>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IResult<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<int>();

            var validator = new CreateBookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var bookToAdd = _mapper.Map<Book>(request);
                bookToAdd.CreatedOn = DateTime.Now;

                await _repository.AddAsync(bookToAdd);
                await _repository.SaveAsync();

                result.Value = bookToAdd.Id;
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
