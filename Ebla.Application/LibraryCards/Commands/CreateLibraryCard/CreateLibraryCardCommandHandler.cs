namespace Ebla.Application.LibraryCards.Commands.CreateLibraryCard
{
    public class CreateLibraryCardCommandHandler : IRequestHandler<CreateLibraryCardCommand, CreateLibraryCommandCardResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly ILibraryCardRepository _repository;
        private readonly IGenericRepository<LibraryCard> _genericRepository;

        public CreateLibraryCardCommandHandler(
            IMapper mapper, 
            IIdentityService identityService,
            ILibraryCardRepository repository,
            IGenericRepository<LibraryCard> genericRepository)
        {
            _mapper = mapper;
            _identityService = identityService;
            _repository = repository;
            _genericRepository = genericRepository;
        }

        public async Task<CreateLibraryCommandCardResponse> Handle(CreateLibraryCardCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateLibraryCommandCardResponse();

            var validator = new CreateLibraryCardCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var user = await _identityService.GetUserAsync(request.UserId);
                if (user == null)
                {
                    response.Errors.Add($"No user with id: {request.UserId} could be found");
                    return response;
                }

                var libraryCard = await _repository.GetLibraryCardAsync(user.Id);
                if (libraryCard != null)
                {
                    response.Errors.Add($"A library card already exists on this user");
                    return response;
                }

                var libraryCardToAdd = _mapper.Map<LibraryCard>(request);
                libraryCardToAdd.CreatedOn = DateTime.Now;
                libraryCardToAdd.ExpiresOn = DateTime.Now.AddYears(1);

                await _genericRepository.AddAsync(libraryCardToAdd);
                await _genericRepository.SaveAsync();

                response.Succeeded = true;
            }
            else
            {
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            return response;
        }
    }
}
