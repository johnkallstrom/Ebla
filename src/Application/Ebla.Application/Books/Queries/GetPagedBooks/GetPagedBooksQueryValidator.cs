namespace Ebla.Application.Books.Queries
{
    public class GetPagedBooksQueryValidator : AbstractValidator<GetPagedBooksQuery>
    {
        public GetPagedBooksQueryValidator()
        {
            RuleFor(x => x.PageNumber).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.PageSize).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}