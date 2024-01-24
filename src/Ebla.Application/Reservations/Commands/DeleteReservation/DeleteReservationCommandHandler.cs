namespace Ebla.Application.Reservations.Commands
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, Result>
    {
        private readonly IGenericRepository<Reservation> _genericRepository;

        public DeleteReservationCommandHandler(IGenericRepository<Reservation> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Result> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteReservationCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var reservationToDelete = await _genericRepository.Get(request.Id);
                if (reservationToDelete is null)
                {
                    throw new NotFoundException(nameof(reservationToDelete), request.Id);
                }

                _genericRepository.Delete(reservationToDelete);
                await _genericRepository.SaveAsync();

                return Result.Success();
            }

            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToArray();
            return Result.Failure(errors);
        }
    }
}
