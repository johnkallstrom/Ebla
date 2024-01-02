namespace Ebla.Application.Statistics.Responses
{
    public record StatisticsDto
    {
        public int TotalBooks { get; set; }
        public int TotalUsers { get; set; }
        public int TotalLoans { get; set; }
        public int TotalReservations { get; set; }
        public Dictionary<string, double> GenrePercentages { get; set; }
    }
}