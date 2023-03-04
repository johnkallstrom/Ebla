namespace Ebla.Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationCommandValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.UserId).NotNull().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}