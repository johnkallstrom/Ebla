namespace Ebla.Web.Features.Libraries
{
    public partial class Details
    {
        [Inject]
        public IGenericHttpService<LibraryViewModel> HttpService { get; set; }

        [Parameter]
        public int LibraryId { get; set; }

        public LibraryViewModel Library { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Library = await HttpService.GetAsync($"{Endpoints.Libraries}/{LibraryId}");
        }
    }
}
