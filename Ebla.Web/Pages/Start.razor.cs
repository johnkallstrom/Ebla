namespace Ebla.Web.Pages
{
    public partial class Start
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await HttpService.GetAsync("/api/authors");
        }
    }
}
