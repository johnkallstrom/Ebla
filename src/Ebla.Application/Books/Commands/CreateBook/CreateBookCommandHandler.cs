namespace Ebla.Application.Books.Commands
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Response<int>>
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IGenericRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var bookToAdd = _mapper.Map<Book>(request);
                bookToAdd.CreatedOn = DateTime.Now;

                await _repository.AddAsync(bookToAdd);
                await _repository.SaveAsync();

                bookToAdd.BookLibraries = new List<BookLibrary>();
                foreach (var libraryId in request.LibraryIds)
                {
                    bookToAdd.BookLibraries.Add(new BookLibrary
                    {
                        BookId = bookToAdd.Id,
                        LibraryId = libraryId
                    });
                }

                await _repository.SaveAsync();

                return Response<int>.Success(bookToAdd.Id);
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return Response<int>.Failure(errors);
        }
    }
}
