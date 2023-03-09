namespace Ebla.Application.LibraryCards.Commands.DeleteLibraryCard
{
    public class DeleteLibraryCardCommandHandler : IRequestHandler<DeleteLibraryCardCommand, IResult>
    {
        private readonly IGenericRepository<LibraryCard> _genericRepository;

        public DeleteLibraryCardCommandHandler(IGenericRepository<LibraryCard> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IResult> Handle(DeleteLibraryCardCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();

            var validator = new DeleteLibraryCardCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var libraryCardToDelete = await _genericRepository.GetByIdAsync(request.Id);
                if (libraryCardToDelete is null)
                {
                    throw new NotFoundException(nameof(libraryCardToDelete), request.Id);
                }

                _genericRepository.Delete(libraryCardToDelete);
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