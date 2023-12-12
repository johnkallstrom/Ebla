namespace Ebla.Application.UseCases.Reservations.Commands
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, Response>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Reservation> _genericRepository;

        public UpdateReservationCommandHandler(
            IMapper mapper, 
            IGenericRepository<Reservation> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public async Task<Response> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateReservationCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var reservationToUpdate = await _genericRepository.GetByIdAsync(request.Id);
                if (reservationToUpdate is null)
                {
                    throw new NotFoundException(nameof(reservationToUpdate), request.Id);
                }

                reservationToUpdate = _mapper.Map(request, reservationToUpdate);
                reservationToUpdate.LastModified = DateTime.Now;

                _genericRepository.Update(reservationToUpdate);
                await _genericRepository.SaveAsync();

                return Response.Success();
            }

            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToArray();
            return Response.Failure(errors);
        }
    }
}
