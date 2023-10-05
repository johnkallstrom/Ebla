namespace Ebla.Application.Libraries.Queries.GetLibraries
{
    public class GetLibrariesQueryHandler : IRequestHandler<GetLibrariesQuery, IEnumerable<LibraryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Library> _repository;

        public GetLibrariesQueryHandler(IGenericRepository<Library> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LibraryDto>> Handle(GetLibrariesQuery request, CancellationToken cancellationToken)
        {
            var libraries = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<LibraryDto>>(libraries);
        }
    }
}
