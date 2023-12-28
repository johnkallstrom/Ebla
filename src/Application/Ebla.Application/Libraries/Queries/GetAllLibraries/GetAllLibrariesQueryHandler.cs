namespace Ebla.Application.Libraries.Queries
{
    public class GetAllLibrariesQueryHandler : IRequestHandler<GetAllLibrariesQuery, IEnumerable<LibrarySlimDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Library> _repository;

        public GetAllLibrariesQueryHandler(IGenericRepository<Library> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LibrarySlimDto>> Handle(GetAllLibrariesQuery request, CancellationToken cancellationToken)
        {
            var libraries = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<LibrarySlimDto>>(libraries);
        }
    }
}