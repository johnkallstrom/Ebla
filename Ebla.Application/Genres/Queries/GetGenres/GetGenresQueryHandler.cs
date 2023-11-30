using Ebla.Application.Interfaces;

namespace Ebla.Application.Genres.Queries.GetGenres
{
    public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, IEnumerable<GenreResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Genre> _repository;

        public GetGenresQueryHandler(IGenericRepository<Genre> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreResponse>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
        {
            var genres = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<GenreResponse>>(genres);
        }
    }
}
