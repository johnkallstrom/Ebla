namespace Ebla.Web.Features.Authors
{
    public partial class Details
    {
        [Inject]
        public IGenericHttpService<AuthorViewModel> HttpService { get; set; }

        [Parameter]
        public int AuthorId { get; set; }

        public AuthorViewModel Author { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Author = await HttpService.GetAsync($"{Endpoints.Authors}/{AuthorId}");
        }
    }
}
