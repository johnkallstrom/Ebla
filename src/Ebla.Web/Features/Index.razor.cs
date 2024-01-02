namespace Ebla.Web.Features
{
    public partial class Index
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public IHttpService HttpService { get; set; }

        public Result<StatisticsViewModel> Model { get; set; }
        public string[] GenreLabels { get; set; }
        public double[] GenrePercentages { get; set; }
        public bool Loading { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                var response = await HttpService.GetAsync(Endpoints.Statistics);

                if (response.IsSuccessStatusCode)
                {
                    Loading = false;
                    Model = await response.Content.ReadFromJsonAsync<Result<StatisticsViewModel>>();

                    GenrePercentages = Model.Data.GenrePercentages.Values.ToArray();
                    GenreLabels = FormatLabels(Model.Data.GenrePercentages.Keys.ToArray(), GenrePercentages);
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
