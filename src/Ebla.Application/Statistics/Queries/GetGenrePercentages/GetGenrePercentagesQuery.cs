namespace Ebla.Application.Statistics.Queries
{
    public class GetGenrePercentagesQuery : IRequest<Dictionary<string, double>>
    {
        public int Amount { get; set; }
    }
}