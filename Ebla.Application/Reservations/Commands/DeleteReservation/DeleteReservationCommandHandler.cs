namespace Ebla.Application.Reservations.Commands.DeleteReservation
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, Response>
    {
        private readonly IGenericRepository<Reservation> _genericRepository;

        public DeleteReservationCommandHandler(IGenericRepository<Reservation> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Response> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteReservationCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var reservationToDelete = await _genericRepository.GetByIdAsync(request.Id);
                if (reservationToDelete is null)
                {
                    throw new NotFoundException(nameof(reservationToDelete), request.Id);
                }

                _genericRepository.Delete(reservationToDelete);
                await _genericRepository.SaveAsync();

                return Response.Success();
            }

            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToArray();
            return Response.Failure(errors);
        }
    }
}
