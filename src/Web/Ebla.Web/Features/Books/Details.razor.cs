namespace Ebla.Web.Features.Books
{
    public partial class Details
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        [Parameter]
        public int BookId { get; set; }

        public BookViewModel Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Books}/{BookId}");

            if (response.IsSuccessStatusCode)
            {
                Model = await response.Content.ReadFromJsonAsync<BookViewModel>();
            }
        }
    }
}
