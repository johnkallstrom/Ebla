namespace Ebla.Application.Books.Commands
{
    public class DeleteBooksCommandValidator : AbstractValidator<DeleteBooksCommand>
    {
        public DeleteBooksCommandValidator()
        {
            RuleFor(x => x.Ids).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}
