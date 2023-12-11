namespace Ebla.Web.Features
{
    public partial class Index
    {
        public double[] PieChartData { get; set; }
        public string[] PieChartLabels { get; set; }

        protected override void OnInitialized()
        {
            PieChartData = new double[] { 50, 35, 15 };
            PieChartLabels = new string[] { "Science Fiction", "Horror", "Non-Fiction" };
        }
    }
}
