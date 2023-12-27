namespace Ebla.Application.Books.Queries
{
    public class GetBooksQueryValidator : AbstractValidator<GetBooksQuery>
    {
        public GetBooksQueryValidator()
        {
            RuleFor(x => x.PageNumber).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.PageSize).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}