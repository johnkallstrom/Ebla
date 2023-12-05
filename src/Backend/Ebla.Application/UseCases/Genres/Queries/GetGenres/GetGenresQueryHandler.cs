namespace Ebla.Application.UseCases.Genres.Queries
{
    public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, IEnumerable<GenreDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Genre> _repository;

        public GetGenresQueryHandler(IGenericRepository<Genre> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDto>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
        {
            var genres = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<GenreDto>>(genres);
        }
    }
}