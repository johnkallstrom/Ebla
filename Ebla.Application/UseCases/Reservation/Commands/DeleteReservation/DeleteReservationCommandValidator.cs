namespace Ebla.Application.UseCases.Reservation.Commands
{
    public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
    {
        public DeleteReservationCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}
