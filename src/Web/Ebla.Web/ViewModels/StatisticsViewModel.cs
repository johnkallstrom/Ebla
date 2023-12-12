namespace Ebla.Web.ViewModels
{
    public class StatisticsViewModel
    {
        public int TotalAmountOfBooks { get; set; }
        public string[] GenresWithMostBooksLabels { get; set; }
        public double[] GenresWithMostBooksPercentages { get; set; }

        public StatisticsViewModel()
        {
            GenresWithMostBooksLabels = new string[] { "Genre Label 1", "Genre Label 2", "Genre Label 3" };
            GenresWithMostBooksPercentages = new double[] { 50, 25, 25 };
        }
    }
}
