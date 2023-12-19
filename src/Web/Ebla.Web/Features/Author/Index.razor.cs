namespace Ebla.Web.Features.Author
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public PagedResult<AuthorViewModel> Model { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await HttpService.GetAsync($"{Endpoints.Authors}?pageNumber={PageNumber}&pageSize={PageSize}");

                if (response.IsSuccessStatusCode)
                {
                    Model = await response.Content.ReadFromJsonAsync<PagedResult<AuthorViewModel>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
