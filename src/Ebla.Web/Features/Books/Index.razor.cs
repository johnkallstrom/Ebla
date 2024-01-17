namespace Ebla.Web.Features.Books
{
    public partial class Index
    {
        [Inject]
        public IDialogService DialogService { get; set; }

        [Inject]
        public IHttpService<BookViewModel> HttpService { get; set; }

        public IEnumerable<BookViewModel> BookList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BookList = await HttpService.GetListAsync(Endpoints.Books);
        }

		protected void ShowCreateBookDialog() => DialogService.Show<CreateBookDialog>();
    }
}