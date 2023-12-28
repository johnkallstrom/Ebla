namespace Ebla.Application.Libraries.Queries
{
    public class GetPagedLibrariesQueryValidator : AbstractValidator<GetPagedLibrariesQuery>
    {
        public GetPagedLibrariesQueryValidator()
        {
            RuleFor(x => x.PageNumber).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.PageSize).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}