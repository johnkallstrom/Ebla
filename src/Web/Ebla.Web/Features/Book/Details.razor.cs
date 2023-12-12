namespace Ebla.Web.Features.Book
{
    public partial class Details
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        [Parameter]
        public int BookId { get; set; }

        public BookViewModel Book { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync($"{Endpoints.Books}/{BookId}");

            if (response.IsSuccessStatusCode)
            {
                Book = await response.Content.ReadFromJsonAsync<BookViewModel>();
            }
        }
    }
}
