namespace Ebla.Application.LibraryCards.Commands.CreateLibraryCard
{
    public class CreateLibraryCardValidator : AbstractValidator<CreateLibraryCardCommand>
    {
        public CreateLibraryCardValidator()
        {
            RuleFor(x => x.PersonalIdentificationNumber).NotEmpty().Must(pin => pin.ToString().Length == 6).WithMessage("Please enter a valid {PropertyName}, must be 6 digits in length");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}