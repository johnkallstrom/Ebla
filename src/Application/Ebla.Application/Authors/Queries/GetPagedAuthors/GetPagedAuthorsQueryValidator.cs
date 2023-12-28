namespace Ebla.Application.Authors.Queries
{
    public class GetPagedAuthorsQueryValidator : AbstractValidator<GetPagedAuthorsQuery>
    {
        public GetPagedAuthorsQueryValidator()
        {
            RuleFor(x => x.PageNumber).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.PageSize).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}