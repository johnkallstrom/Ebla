namespace Ebla.Application.Statistics.Queries
{
    public class GetGenrePercentagesQueryValidator : AbstractValidator<GetGenrePercentagesQuery>
    {
        public GetGenrePercentagesQueryValidator()
        {
            RuleFor(x => x.Count).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}