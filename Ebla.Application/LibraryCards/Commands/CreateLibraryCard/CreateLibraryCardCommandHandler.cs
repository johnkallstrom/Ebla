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
                    response.Errors = new List<string> { $"No user with id: {request.UserId} exists in our database" };
                    return response;
                }

                if (await _repository.LibraryCardExists(request.UserId) == true)
                {
                    response.Errors = new List<string> { $"The user with id: {request.UserId} already has an existing library card" };
                    return response;
                }

                var libraryCardToAdd = _mapper.Map<LibraryCard>(request);
                libraryCardToAdd.CreatedOn = DateTime.Now;
                libraryCardToAdd.Expires = DateTime.Now.AddYears(1);

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
