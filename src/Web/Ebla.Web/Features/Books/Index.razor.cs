namespace Ebla.Web.Features.Books
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public List<BookViewModel> BookList { get; set; } = new List<BookViewModel>();

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Books}");

            if (response.IsSuccessStatusCode)
            {
                BookList = await response.Content.ReadFromJsonAsync<List<BookViewModel>>();
            }
        }
    }
}