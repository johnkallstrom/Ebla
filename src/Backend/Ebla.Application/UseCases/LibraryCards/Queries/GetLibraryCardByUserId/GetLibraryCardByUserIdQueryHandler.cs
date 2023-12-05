namespace Ebla.Application.UseCases.LibraryCards.Queries
{
    public class GetLibraryCardByUserIdQueryHandler : IRequestHandler<GetLibraryCardByUserIdQuery, LibraryCardDto>
    {
        private readonly IMapper _mapper;
        private readonly ILibraryCardRepository _repository;

        public GetLibraryCardByUserIdQueryHandler(
            ILibraryCardRepository repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LibraryCardDto> Handle(GetLibraryCardByUserIdQuery request, CancellationToken cancellationToken)
        {
            var libraryCard = await _repository.GetLibraryCardAsync(request.UserId);

            if (libraryCard is null)
            {
                throw new NotFoundException(nameof(libraryCard), request.UserId);
            }

            return _mapper.Map<LibraryCardDto>(libraryCard);
        }
    }
}
