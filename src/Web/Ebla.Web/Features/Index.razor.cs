namespace Ebla.Web.Features
{
    public partial class Index
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public IHttpService HttpService { get; set; }

        public StatisticsViewModel Model { get; set; } = new StatisticsViewModel();
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
                    Model = await response.Content.ReadFromJsonAsync<StatisticsViewModel>();
                }
            }
        }
    }
}
