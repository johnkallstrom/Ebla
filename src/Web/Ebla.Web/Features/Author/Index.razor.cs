namespace Ebla.Web.Features.Author
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public PagedResult<AuthorViewModel> Model { get; set; } = new PagedResult<AuthorViewModel>();
        public bool Loading { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Authors}?pageNumber={Model.PageNumber}&pageSize={Model.PageSize}");

            if (response.IsSuccessStatusCode)
            {
                Model = await response.Content.ReadFromJsonAsync<PagedResult<AuthorViewModel>>();
                Loading = false;
            }
        }

        private async Task OnPageChangeAsync(int selectedPage)
        {
            Model.PageNumber = selectedPage;

            var response = await HttpService.GetAsync($"{Endpoints.Authors}?pageNumber={Model.PageNumber}&pageSize={Model.PageSize}");

            if (response.IsSuccessStatusCode)
            {
                Model = await response.Content.ReadFromJsonAsync<PagedResult<AuthorViewModel>>();
                Loading = false;
            }
        }
    }
}