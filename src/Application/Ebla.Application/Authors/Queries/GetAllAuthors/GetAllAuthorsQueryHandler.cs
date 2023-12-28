namespace Ebla.Application.Authors.Queries
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<AuthorSlimDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Author> _repository;

        public GetAllAuthorsQueryHandler(IGenericRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorSlimDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<AuthorSlimDto>>(authors);
        }
    }
}