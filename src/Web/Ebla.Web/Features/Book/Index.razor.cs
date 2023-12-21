namespace Ebla.Web.Features.Book
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public PagedResult<BookViewModel> Model { get; set; } = new PagedResult<BookViewModel>();
        public bool Loading { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Books}?pageNumber={Model.PageNumber}&pageSize={Model.PageSize}");

            if (response.IsSuccessStatusCode)
            {
                Model = await response.Content.ReadFromJsonAsync<PagedResult<BookViewModel>>();
                Loading = false;
            }
        }

        private async Task OnPageChangeAsync(int selectedPage)
        {
            Model.PageNumber = selectedPage;

            var response = await HttpService.GetAsync($"{Endpoints.Books}?pageNumber={Model.PageNumber}&pageSize={Model.PageSize}");

            if (response.IsSuccessStatusCode)
            {
                Model = await response.Content.ReadFromJsonAsync<PagedResult<BookViewModel>>();
                Loading = false;
            }
        }
    }
}