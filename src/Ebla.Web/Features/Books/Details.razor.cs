namespace Ebla.Web.Features.Books
{
    public partial class Details
    {
        [Inject]
        public IGenericHttpService<BookViewModel> HttpService { get; set; }

        [Parameter]
        public int BookId { get; set; }

        public BookViewModel Book { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Book = await HttpService.GetAsync($"{Endpoints.Books}/{BookId}");
        }
    }
}
