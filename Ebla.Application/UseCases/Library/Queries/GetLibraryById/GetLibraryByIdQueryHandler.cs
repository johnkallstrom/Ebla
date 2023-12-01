namespace Ebla.Application.UseCases.Library.Queries
{
    public class GetLibraryByIdQueryHandler : IRequestHandler<GetLibraryByIdQuery, LibraryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILibraryRepository _repository;

        public GetLibraryByIdQueryHandler(IMapper mapper, ILibraryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<LibraryResponse> Handle(GetLibraryByIdQuery request, CancellationToken cancellationToken)
        {
            var library = await _repository.GetLibraryByIdAsync(request.Id);

            if (library is null)
            {
                throw new NotFoundException(nameof(library), request.Id);
            }

            return _mapper.Map<LibraryResponse>(library);
        }
    }
}
