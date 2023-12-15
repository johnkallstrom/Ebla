namespace Ebla.Application.UseCases.LibraryCards.Queries
{
    public class GetLibraryCardsQueryHandler : IRequestHandler<GetLibraryCardsQuery, IEnumerable<LibraryCardDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILibraryCardRepository _repository;

        public GetLibraryCardsQueryHandler(IMapper mapper, ILibraryCardRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<LibraryCardDto>> Handle(GetLibraryCardsQuery request, CancellationToken cancellationToken)
        {
            var libraryCards = await _repository.GetAllLibraryCardsAsync();

            return _mapper.Map<IEnumerable<LibraryCardDto>>(libraryCards);
        }
    }
}