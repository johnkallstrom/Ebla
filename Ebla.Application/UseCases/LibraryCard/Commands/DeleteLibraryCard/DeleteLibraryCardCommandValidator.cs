namespace Ebla.Application.UseCases.LibraryCard.Commands
{
    public class DeleteLibraryCardCommandValidator : AbstractValidator<DeleteLibraryCardCommand>
    {
        public DeleteLibraryCardCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}
