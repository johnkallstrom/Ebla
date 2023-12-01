namespace Ebla.Application.UseCases.Reservation.Commands
{
    public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
    {
        public UpdateReservationCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.ExpiresOn).NotNull().WithMessage("Please enter a valid date for {PropertyName}");
        }
    }
}
