namespace Ebla.Web.Features.Authors
{
    public partial class Index
    {
        [Inject]
        public IHttpService<AuthorViewModel> HttpService { get; set; }

        public IEnumerable<AuthorViewModel> AuthorList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AuthorList = await HttpService.GetListAsync($"{Endpoints.Authors}");
        }
    }
}