namespace Ebla.Web.Pages
{
    public partial class Books
    {
        [Inject]
        public IBookHttpService BookHttpService { get; set; }

        public List<BookViewModel> BookList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BookList = await BookHttpService.GetAllAsync();
        }
    }
}
