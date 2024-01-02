namespace Ebla.Web.Features.Authors
{
    public partial class Index
    {
        [Inject]
        public IGenericHttpService<AuthorViewModel> HttpService { get; set; }

        public IEnumerable<AuthorViewModel> AuthorList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AuthorList = await HttpService.GetListAsync($"{Endpoints.Authors}");
        }
    }
}