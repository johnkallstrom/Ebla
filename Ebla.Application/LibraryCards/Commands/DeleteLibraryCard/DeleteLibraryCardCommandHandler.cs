namespace Ebla.Application.LibraryCards.Commands.DeleteLibraryCard
{
    public class DeleteLibraryCardCommandHandler : IRequestHandler<DeleteLibraryCardCommand, DeleteLibraryCardCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly ILibraryCardRepository _repository;
        private readonly IGenericRepository<LibraryCard> _genericRepository;

        public DeleteLibraryCardCommandHandler(
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

        public async Task<DeleteLibraryCardCommandResponse> Handle(DeleteLibraryCardCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteLibraryCardCommandResponse();

            var validator = new DeleteLibraryCardCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var libraryCardToDelete = await _genericRepository.GetByIdAsync(request.Id);

                if (libraryCardToDelete == null)
                {
                    response.Errors.Add($"No library card with id: {request.Id} could be found");
                    return response;
                }

                _genericRepository.Delete(libraryCardToDelete);
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