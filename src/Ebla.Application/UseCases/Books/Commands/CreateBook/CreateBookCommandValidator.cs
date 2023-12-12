namespace Ebla.Application.UseCases.Books.Commands
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.Description).NotEmpty().Length(1, 500).WithMessage("Please enter a valid {PropertyName}, must be between {MinLength} and {MaxLength} characters");
            RuleFor(x => x.Pages).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.Published).NotNull().WithMessage("Please enter a valid date for {PropertyName}");
            RuleFor(x => x.Language).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.AuthorId).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.GenreId).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}
