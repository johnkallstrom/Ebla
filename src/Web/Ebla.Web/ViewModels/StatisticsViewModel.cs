namespace Ebla.Web.ViewModels
{
    public class StatisticsViewModel
    {
        public int TotalBooks { get; set; }
        public string[] GenreLabels { get; set; }
        public double[] GenrePercentages { get; set; }
    }
}
