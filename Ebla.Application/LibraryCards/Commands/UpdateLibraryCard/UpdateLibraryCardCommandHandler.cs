namespace Ebla.Application.LibraryCards.Commands.UpdateLibraryCard
{
    public class UpdateLibraryCardCommandHandler : IRequestHandler<UpdateLibraryCardCommand, IResult>
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

        public async Task<IResult> Handle(UpdateLibraryCardCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            var validator = new UpdateLibraryCardCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var libraryCardToUpdate = await _genericRepository.GetByIdAsync(request.Id);
                if (libraryCardToUpdate is null)
                {
                    throw new NotFoundException(nameof(libraryCardToUpdate), request.Id);
                }

                libraryCardToUpdate = _mapper.Map(request, libraryCardToUpdate);
                libraryCardToUpdate.LastModified = DateTime.Now;

                _genericRepository.Update(libraryCardToUpdate);
                await _genericRepository.SaveAsync();

                result.Success();
            }
            else
            {
                result.Failure(validationResult.Errors.Select(x => x.ErrorMessage).ToArray());
            }

            return result;
        }
    }
}
