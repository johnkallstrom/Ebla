namespace Ebla.Web.Features
{
    public partial class Index
    {
        public double[] GenreData { get; set; }
        public string[] GenreLabels { get; set; }

        protected override void OnInitialized()
        {
            GenreData = new double[] { 50, 35, 15 };
            GenreLabels = new string[] { "Science Fiction", "Horror", "Non-Fiction" };
        }
    }
}
