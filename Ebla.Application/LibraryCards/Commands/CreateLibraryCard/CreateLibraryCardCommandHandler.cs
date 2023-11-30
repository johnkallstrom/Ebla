using Ebla.Application.Interfaces;

namespace Ebla.Application.LibraryCards.Commands.CreateLibraryCard
{
    public class CreateLibraryCardCommandHandler : IRequestHandler<CreateLibraryCardCommand, Response<int>>
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly ILibraryCardRepository _repository;
        private readonly IGenericRepository<LibraryCard> _genericRepository;

        public CreateLibraryCardCommandHandler(
            IMapper mapper,
            IIdentityService identityService,
            ILibraryCardRepository repository,
            IGenericRepository<LibraryCard> genericRepository,
            ILibraryRepository libraryRepository)
        {
            _mapper = mapper;
            _identityService = identityService;
            _repository = repository;
            _genericRepository = genericRepository;
            _libraryRepository = libraryRepository;
        }

        public async Task<Response<int>> Handle(CreateLibraryCardCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLibraryCardCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var user = await _identityService.GetUserAsync(request.UserId);
                if (user is null)
                {
                    throw new NotFoundException(nameof(user), request.UserId);
                }

                var library = await _libraryRepository.GetLibraryByIdAsync(request.LibraryId);
                if (library is null)
                {
                    throw new NotFoundException(nameof(library), request.LibraryId);
                }

                var libraryCard = await _repository.GetLibraryCardAsync(user.Id);
                if (libraryCard is null)
                {
                    var libraryCardToAdd = _mapper.Map<LibraryCard>(request);
                    libraryCardToAdd.CreatedOn = DateTime.Now;
                    libraryCardToAdd.ExpiresOn = DateTime.Now.AddYears(1);

                    await _genericRepository.AddAsync(libraryCardToAdd);
                    await _genericRepository.SaveAsync();

                    return Response<int>.Success(libraryCardToAdd.Id);
                }
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return Response<int>.Failure(errors);
        }
    }
}
