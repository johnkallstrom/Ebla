namespace Ebla.Web.Features.ViewModels
{
    public class StatisticsViewModel
    {
        public int TotalBooks { get; set; }
        public int TotalUsers { get; set; }
        public int TotalLoans { get; set; }
        public int TotalReservations { get; set; }
        public Dictionary<string, double> GenrePercentages { get; set; }
    }
}
