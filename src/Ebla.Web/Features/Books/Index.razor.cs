namespace Ebla.Web.Features.Books
{
    public partial class Index
    {
        [Inject]
        public IGenericHttpService<BookViewModel> HttpService { get; set; }

        public IEnumerable<BookViewModel> BookList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BookList = await HttpService.GetListAsync($"{Endpoints.Books}");
        }
    }
}