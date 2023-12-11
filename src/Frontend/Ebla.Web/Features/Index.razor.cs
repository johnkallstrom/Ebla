namespace Ebla.Web.Features
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public StatisticsViewModel Model { get; set; } = new StatisticsViewModel();

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync(Endpoints.Statistics);

            if (response.IsSuccessStatusCode)
            {
                Model = await response.Content.ReadFromJsonAsync<StatisticsViewModel>();
            }
        }
    }
}
