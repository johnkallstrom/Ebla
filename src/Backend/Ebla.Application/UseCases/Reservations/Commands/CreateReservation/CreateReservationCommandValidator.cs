namespace Ebla.Application.UseCases.Reservations.Commands
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