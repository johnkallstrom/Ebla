using Ebla.Application.Interfaces;

namespace Ebla.Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Author> _repository;

        public GetAuthorByIdQueryHandler(IMapper mapper, IGenericRepository<Author> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<AuthorResponse> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.Id);

            if (author is null)
            {
                throw new NotFoundException(nameof(author), request.Id);
            }

            return _mapper.Map<AuthorResponse>(author);
        }
    }
}
