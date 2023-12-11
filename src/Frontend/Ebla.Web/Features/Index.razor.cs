namespace Ebla.Web.Features
{
    public partial class Index
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public IHttpService HttpService { get; set; }

        public StatisticsViewModel Model { get; set; }
        public bool Loading { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            Model = new StatisticsViewModel();
            Model.GenresWithMostBooksLabels = new string[] { "Genre Label 1", "Genre Label 2", "Genre Label 3" };
            Model.GenresWithMostBooksPercentages = new double[] { 50, 25, 25 };

            if (user.Identity.IsAuthenticated)
            {
                var response = await HttpService.GetAsync(Endpoints.Statistics);

                if (response.IsSuccessStatusCode)
                {
                    Loading = false;
                    Model = await response.Content.ReadFromJsonAsync<StatisticsViewModel>();
                }
            }
        }
    }
}
