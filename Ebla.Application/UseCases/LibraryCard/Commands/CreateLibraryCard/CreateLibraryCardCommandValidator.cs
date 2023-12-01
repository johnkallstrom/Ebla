namespace Ebla.Application.UseCases.LibraryCard.Commands
{
    public class CreateLibraryCardCommandValidator : AbstractValidator<CreateLibraryCardCommand>
    {
        public CreateLibraryCardCommandValidator()
        {
            RuleFor(x => x.PIN).NotEmpty().Must(pin => pin.ToString().Length == 6).WithMessage("Please enter a valid {PropertyName}, must be 6 digits in length");
            RuleFor(x => x.LibraryId).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}