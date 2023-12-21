namespace Ebla.Web.Features.Library
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public PagedResult<LibraryViewModel> Model { get; set; } = new PagedResult<LibraryViewModel>();
        public bool Loading { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Libraries}?pageNumber={Model.PageNumber}&pageSize={Model.PageSize}");

            if (response.IsSuccessStatusCode)
            {
                Model = await response.Content.ReadFromJsonAsync<PagedResult<LibraryViewModel>>();
                Loading = false;
            }
        }

        private async Task OnPageChangeAsync(int selectedPage)
        {
            Model.PageNumber = selectedPage;

            var response = await HttpService.GetAsync($"{Endpoints.Libraries}?pageNumber={Model.PageNumber}&pageSize={Model.PageSize}");

            if (response.IsSuccessStatusCode)
            {
                Model = await response.Content.ReadFromJsonAsync<PagedResult<LibraryViewModel>>();
                Loading = false;
            }
        }
    }
}
