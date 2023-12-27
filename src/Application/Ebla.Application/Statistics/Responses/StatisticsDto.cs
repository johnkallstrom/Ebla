namespace Ebla.Application.Statistics.Responses
{
    public record StatisticsDto
    {
        public int TotalBooks { get; set; }
        public int TotalLoans { get; set; }
        public int TotalReservations { get; set; }
        public string[] GenreLabels { get; set; }
        public double[] GenrePercentages { get; set; }
    }
}