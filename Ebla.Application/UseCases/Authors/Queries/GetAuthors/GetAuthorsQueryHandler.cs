namespace Ebla.Application.UseCases.Authors.Queries
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, IEnumerable<AuthorSlimResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Author> _repository;

        public GetAuthorsQueryHandler(IGenericRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorSlimResponse>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<AuthorSlimResponse>>(authors);
        }
    }
}