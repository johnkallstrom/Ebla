namespace Ebla.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("The {PropertyName} cannot be null or empty.");
            RuleFor(x => x.Description).NotEmpty().Length(1, 500).WithMessage("The {PropertyName} cannot be empty and must be between {MinLength} to {MaxLength} characters.");
            RuleFor(x => x.Pages).NotEmpty().WithMessage("The {PropertyName} cannot be null or 0.");
            RuleFor(x => x.Published).NotNull().WithMessage("The {PropertyName} cannot be null.");
            RuleFor(x => x.Language).NotEmpty().WithMessage("The {PropertyName} cannot be null or empty.");
            RuleFor(x => x.AuthorId).NotEmpty().WithMessage("The {PropertyName} cannot be null or 0.");
            RuleFor(x => x.GenreId).NotEmpty().WithMessage("The {PropertyName} cannot be null or 0.");
        }
    }
}
