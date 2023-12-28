namespace Ebla.Application.Authors.Queries
{
    public class GetPagedAuthorsQueryHandler : IRequestHandler<GetPagedAuthorsQuery, PagedResponse<AuthorSlimDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Author> _repository;

        public GetPagedAuthorsQueryHandler(IGenericRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<AuthorSlimDto>> Handle(GetPagedAuthorsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetPagedAuthorsQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                int pageNumber = request.PageNumber;
                int pageSize = request.PageSize;

                int totalRecords = await _repository.GetTotalAsync();
                int totalPages = Convert.ToInt32(Math.Ceiling((double)totalRecords / pageSize));

                var authors = await _repository.GetPagedAsync(pageNumber, pageSize);
                var dtos = _mapper.Map<IEnumerable<AuthorSlimDto>>(authors);

                return PagedResponse<AuthorSlimDto>.Success(
                    pageNumber, 
                    pageSize, 
                    totalPages, 
                    totalRecords, 
                    dtos);
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return PagedResponse<AuthorSlimDto>.Failure(errors);
        }
    }
}