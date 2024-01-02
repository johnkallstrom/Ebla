namespace Ebla.Web.Features.Libraries
{
    public partial class Index
    {
        [Inject]
        public IHttpService<LibraryViewModel> HttpService { get; set; }

        public IEnumerable<LibraryViewModel> LibraryList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            LibraryList = await HttpService.GetListAsync($"{Endpoints.Libraries}");
        }
    }
}