namespace Ebla.Web.Features.Books
{
    public partial class Index
    {
        [Inject]
        public IDialogService DialogService { get; set; }

        [Inject]
        public IHttpService<BookViewModel> HttpService { get; set; }

        public IEnumerable<BookViewModel> BookList { get; set; }
        public HashSet<BookViewModel> SelectedBooks { get; set; } = new HashSet<BookViewModel>();

        protected override async Task OnInitializedAsync()
        {
            BookList = await HttpService.GetListAsync(Endpoints.Books);
        }

        protected async Task ShowCreateDialog()
        {
            var dialogRef = await DialogService.ShowAsync<CreateFormDialog>("Create a new book");

            var dialogResult = await dialogRef.Result;
            if (dialogResult.Data is true && dialogResult.Canceled is false)
            {
                BookList = await HttpService.GetListAsync(Endpoints.Books);
            }
        }

        protected async Task ShowDeleteConfirmationDialog()
        {
            var parameters = new DialogParameters
            {
                { "BooksToDelete", SelectedBooks }
            };

            var dialogRef = await DialogService.ShowAsync<DeleteConfirmationDialog>("Delete books", parameters);
        }
    }
}