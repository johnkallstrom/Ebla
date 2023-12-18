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
            int totalAuthors = await _repository.GetTotalAsync();

            var response = new PagedResponse<AuthorSlimDto>();

            var authors = await _repository.GetPagedAsync(pageNumber, pageSize);
            var dtos = _mapper.Map<IEnumerable<AuthorSlimDto>>(authors);

            response.PageNumber = pageNumber;
            response.PageSize = pageSize;
            response.TotalPages = totalAuthors / pageSize;
            response.Data = dtos;

            return response;
        }
    }
}