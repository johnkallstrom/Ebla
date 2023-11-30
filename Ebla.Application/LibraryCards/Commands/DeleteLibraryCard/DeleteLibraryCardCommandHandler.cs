using Ebla.Application.Interfaces;

namespace Ebla.Application.LibraryCards.Commands.DeleteLibraryCard
{
    public class DeleteLibraryCardCommandHandler : IRequestHandler<DeleteLibraryCardCommand, Response>
    {
        private readonly IGenericRepository<LibraryCard> _genericRepository;

        public DeleteLibraryCardCommandHandler(IGenericRepository<LibraryCard> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Response> Handle(DeleteLibraryCardCommand request, CancellationToken cancellationToken)
        {
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
                
                return Response.Success();
            }

            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToArray();
            return Response.Failure(errors);
        }
    }
}