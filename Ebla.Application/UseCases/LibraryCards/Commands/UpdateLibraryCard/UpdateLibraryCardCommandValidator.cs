namespace Ebla.Application.UseCases.LibraryCards.Commands
{
    public class UpdateLibraryCardCommandValidator : AbstractValidator<UpdateLibraryCardCommand>
    {
        public UpdateLibraryCardCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.PIN).NotEmpty().Must(pin => pin.ToString().Length == 6).WithMessage("Please enter a valid {PropertyName}, must be 6 digits in length");
            RuleFor(x => x.Expires).NotNull().GreaterThan(DateTime.Now).WithMessage("Please enter a valid {PropertyName}, must be greater than todays date");
        }
    }
}