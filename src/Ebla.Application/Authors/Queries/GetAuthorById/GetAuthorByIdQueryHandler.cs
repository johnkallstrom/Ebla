namespace Ebla.Application.Authors.Queries
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Author> _repository;

        public GetAuthorByIdQueryHandler(IMapper mapper, IGenericRepository<Author> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _repository.Get(request.Id);

            if (author is null)
            {
                throw new NotFoundException(nameof(author), request.Id);
            }

            return _mapper.Map<AuthorDto>(author);
        }
    }
}