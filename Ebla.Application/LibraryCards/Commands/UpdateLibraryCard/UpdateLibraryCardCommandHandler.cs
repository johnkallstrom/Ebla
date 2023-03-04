namespace Ebla.Application.LibraryCards.Commands.UpdateLibraryCard
{
    public class UpdateLibraryCardCommandHandler : IRequestHandler<UpdateLibraryCardCommand, UpdateLibraryCardCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<LibraryCard> _genericRepository;

        public UpdateLibraryCardCommandHandler(
            IMapper mapper,
            IGenericRepository<LibraryCard> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public async Task<UpdateLibraryCardCommandResponse> Handle(UpdateLibraryCardCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateLibraryCardCommandResponse();

            var validator = new UpdateLibraryCardCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var libraryCardToUpdate = await _genericRepository.GetByIdAsync(request.Id);

                if (libraryCardToUpdate == null)
                {
                    response.Errors.Add($"No library card with id: {request.Id} could be found");
                    return response;
                }

                libraryCardToUpdate = _mapper.Map(request, libraryCardToUpdate);
                libraryCardToUpdate.LastModified = DateTime.Now;

                _genericRepository.Update(libraryCardToUpdate);
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
