namespace Ebla.Web.Features.Statistics
{
    public partial class Index
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public IHttpService<Response<StatisticsViewModel>> HttpService { get; set; }

        public Response<StatisticsViewModel> Model { get; set; }
        public string[] LoanReservationXAxisLabels { get; set; } = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public List<ChartSeries> LoanReservationChartSeries { get; set; } = new List<ChartSeries>
        {
            new ChartSeries { Name = "Loans", Data = new double[] { 85, 72, 69, 31, 22, 55, 97, 75, 45, 28, 15, 7 }},
            new ChartSeries { Name = "Reservations", Data = new double[] { 44, 12, 7, 3, 59, 68, 91, 83, 25, 10, 3 }}
        };
        public string[] GenreLabels { get; set; }
        public double[] GenrePercentages { get; set; }
        public bool Loading { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                Model = await HttpService.GetAsync(Endpoints.Statistics);
                if (Model.Succeeded)
                {
                    GenrePercentages = Model.Data.GenrePercentages.Values.ToArray();
                    GenreLabels = FormatLabels(Model.Data.GenrePercentages.Keys.ToArray(), GenrePercentages);
                    Loading = false;
                }
            }
        }

        private string[] FormatLabels(string[] labels, double[] percentages)
        {
            var formattedLabels = new List<string>();
            for (int i = 0; i < labels.Count(); i++)
            {
                string label = labels[i];
                double percentage = percentages[i];

                string newLabel = $"{label} ({percentage}%)";
                formattedLabels.Add(newLabel);
            }

            return formattedLabels.ToArray();
        }
    }
}
