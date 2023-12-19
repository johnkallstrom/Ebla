namespace Ebla.Web.Features.Author
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public PagedResult<AuthorViewModel> Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var response = await HttpService.GetAsync(Endpoints.Authors);

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
