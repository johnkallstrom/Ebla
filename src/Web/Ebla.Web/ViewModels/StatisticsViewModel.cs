namespace Ebla.Web.ViewModels
{
    public class StatisticsViewModel
    {
        public int TotalBooks { get; set; }
        public Dictionary<string, double> GenreData { get; set; }
        public string[] GenreLabels { get; set; }
        public double[] GenrePercentages { get; set; }

        public StatisticsViewModel()
        {
            GenreLabels = new string[] { "Science Fiction", "Horror", "Non-Fiction" };
            GenrePercentages = new double[] { 40, 35, 25 };
        }
    }
}
