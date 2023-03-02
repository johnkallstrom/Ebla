namespace Ebla.Application.LibraryCards.Commands.CreateLibraryCard
{
    public class CreateLibraryCardCommandHandler : IRequestHandler<CreateLibraryCardCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<LibraryCard> _repository;

        public CreateLibraryCardCommandHandler(IGenericRepository<LibraryCard> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateLibraryCardCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var libraryCard = _mapper.Map<LibraryCard>(request);
                libraryCard.CreatedOn = DateTime.Now;

                await _repository.AddAsync(libraryCard);
                await _repository.SaveAsync();
            }

            return Unit.Value;
        }
    }
}
