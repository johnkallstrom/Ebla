namespace Ebla.Web.ViewModels
{
    public class StatisticsViewModel
    {
        public int TotalBooks { get; set; }
        public string[] GenreLabels { get; set; }
        public double[] GenreData { get; set; }

        public StatisticsViewModel()
        {
            GenreLabels = new string[] { "Science Fiction", "Horror", "Non-Fiction" };
            GenreData = new double[] { 40, 35, 25 };
        }
    }
}
