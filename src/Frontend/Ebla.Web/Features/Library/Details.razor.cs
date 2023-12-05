namespace Ebla.Web.Features.Library
{
    public partial class Details
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        [Parameter]
        public int LibraryId { get; set; }

        public LibraryViewModel Library { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Libraries}/{LibraryId}");

            if (response.IsSuccessStatusCode)
            {
                Library = await response.Content.ReadFromJsonAsync<LibraryViewModel>();
            }
        }
    }
}
