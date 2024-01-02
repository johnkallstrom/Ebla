namespace Ebla.Web.Features.Libraries
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public List<LibraryViewModel> LibraryList { get; set; } = new List<LibraryViewModel>();

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Libraries}");

            if (response.IsSuccessStatusCode)
            {
                LibraryList = await response.Content.ReadFromJsonAsync<List<LibraryViewModel>>();
            }
        }
    }
}
