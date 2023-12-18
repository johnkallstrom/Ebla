namespace Ebla.Application.UseCases.Authors.Queries
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, PagedResponse<AuthorSlimDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Author> _repository;

        public GetAuthorsQueryHandler(IGenericRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<AuthorSlimDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            int pageNumber = request.PageNumber;
            int pageSize = request.PageSize;

            var response = new PagedResponse<AuthorSlimDto>();

            var authors = await _repository.GetPagedAsync(pageNumber, pageSize);
            var data = _mapper.Map<IEnumerable<AuthorSlimDto>>(authors);

            response.PageNumber = pageSize;
            response.PageSize = pageNumber;
            response.TotalPages = 0;
            response.Data = data;

            return response;
        }
    }
}