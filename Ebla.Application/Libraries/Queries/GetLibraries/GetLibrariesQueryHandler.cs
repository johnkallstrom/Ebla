namespace Ebla.Application.Libraries.Queries.GetLibraries
{
    public class GetLibrariesQueryHandler : IRequestHandler<GetLibrariesQuery, IEnumerable<LibrarySlimDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILibraryRepository _repository;

        public GetLibrariesQueryHandler(IMapper mapper, ILibraryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<LibrarySlimDto>> Handle(GetLibrariesQuery request, CancellationToken cancellationToken)
        {
            var libraries = await _repository.GetAllLibrariesAsync();

            return _mapper.Map<IEnumerable<LibrarySlimDto>>(libraries);
        }
    }
}
