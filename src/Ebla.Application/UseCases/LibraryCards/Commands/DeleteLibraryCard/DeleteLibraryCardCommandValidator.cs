namespace Ebla.Application.UseCases.LibraryCards.Commands
{
    public class DeleteLibraryCardCommandValidator : AbstractValidator<DeleteLibraryCardCommand>
    {
        public DeleteLibraryCardCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}
