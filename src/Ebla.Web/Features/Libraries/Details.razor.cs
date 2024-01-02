namespace Ebla.Web.Features.Libraries
{
    public partial class Details
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        [Parameter]
        public int LibraryId { get; set; }

        public LibraryViewModel Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Libraries}/{LibraryId}");

            if (response.IsSuccessStatusCode)
            {
                Model = await response.Content.ReadFromJsonAsync<LibraryViewModel>();
            }
        }
    }
}
