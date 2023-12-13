namespace Ebla.Application.UseCases.Statistics.Responses
{
    public record StatisticsDto
    {
        public int TotalBooks { get; set; }
        public string[] GenreLabels { get; set; }
        public double[] GenrePercentages { get; set; }
    }
}