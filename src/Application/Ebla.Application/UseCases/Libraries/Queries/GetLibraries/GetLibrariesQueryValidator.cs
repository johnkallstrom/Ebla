namespace Ebla.Application.UseCases.Libraries.Queries
{
    public class GetLibrariesQueryValidator : AbstractValidator<GetLibrariesQuery>
    {
        public GetLibrariesQueryValidator()
        {
            RuleFor(x => x.PageNumber).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.PageSize).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}