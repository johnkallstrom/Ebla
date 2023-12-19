namespace Ebla.Application.UseCases.Authors.Queries
{
    public class GetAuthorsQueryValidator : AbstractValidator<GetAuthorsQuery>
    {
        public GetAuthorsQueryValidator()
        {
            RuleFor(x => x.PageNumber).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.PageSize).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}