namespace Ebla.Application.LibraryCards.Commands.CreateLibraryCard
{
    public class CreateLibraryCardCommandHandler : IRequestHandler<CreateLibraryCardCommand, Unit>
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<LibraryCard> _repository;

        public CreateLibraryCardCommandHandler(IGenericRepository<LibraryCard> repository, IMapper mapper, IIdentityService identityService)
        {
            _repository = repository;
            _mapper = mapper;
            _identityService = identityService;
        }

        public async Task<Unit> Handle(CreateLibraryCardCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var libraryCard = _mapper.Map<LibraryCard>(request);
                libraryCard.CreatedOn = DateTime.Now;
                libraryCard.Expires = DateTime.Now.AddYears(1);

                await _repository.AddAsync(libraryCard);
                await _repository.SaveAsync();
            }

            return Unit.Value;
        }
    }
}
