namespace Ebla.Application.UseCases.Books.Queries
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, PagedResponse<BookSlimDto>>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<BookSlimDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetBooksQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                int pageNumber = request.PageNumber;
                int pageSize = request.PageSize;

                int totalRecords = await _repository.GetTotalBooksAsync();
                int totalPages = Convert.ToInt32(Math.Ceiling((double)totalRecords / pageSize));

                var books = await _repository.GetPagedBooksAsync(pageNumber, pageSize);
                var dtos = _mapper.Map<IEnumerable<BookSlimDto>>(books);

                return PagedResponse<BookSlimDto>.Success(pageNumber, pageSize, totalPages, totalRecords, dtos);
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return PagedResponse<BookSlimDto>.Failure(errors);
        }
    }
}
