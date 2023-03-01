namespace Ebla.Application.Common.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("The {PropertyName} cannot be null or 0.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("The {PropertyName} cannot be null or empty.");
            RuleFor(x => x.Description).NotEmpty().Length(1, 500).WithMessage("The {PropertyName} cannot be empty and must be between {MinLength} to {MaxLength} characters.");
            RuleFor(x => x.Pages).NotEmpty().WithMessage("The {PropertyName} cannot be null or 0.");
            RuleFor(x => x.Published).NotNull().WithMessage("The {PropertyName} cannot be null.");
            RuleFor(x => x.Language).NotEmpty().WithMessage("The {PropertyName} cannot be null or empty.");
            RuleFor(x => x.CreatedOn).NotNull().Equal(DateTime.Now).WithMessage("The {PropertyName} cannot be null and must be equal to {ComparisonValue}.");
            RuleFor(x => x.AuthorId).NotEmpty().WithMessage("The {PropertyName} cannot be null or 0.");
            RuleFor(x => x.GenreId).NotEmpty().WithMessage("The {PropertyName} cannot be null or 0.");
        }
    }
}