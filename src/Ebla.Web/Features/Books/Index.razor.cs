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
        public bool DisableEditButton { get; set; } = true;
        public bool DisableDeleteButton { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            BookList = await HttpService.GetListAsync(Endpoints.Books);
        }

        protected void SelectedBooksChanged(HashSet<BookViewModel> values)
        {
            int count = values.Count();

            if (count == 1)
            {
                DisableEditButton = false;
            }
            else
            {
                DisableEditButton = true;
            }

            if (count > 0)
            {
                DisableDeleteButton = false;
            }
            else
            {
                DisableDeleteButton = true;
            }
        }

        protected async Task ShowCreateDialog()
        {
            var options = new DialogOptions
            {
                Position = DialogPosition.Center,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true,
                DisableBackdropClick = true,
                CloseButton = true
            };

            var dialogRef = await DialogService.ShowAsync<CreateFormDialog>("Create a new book", options);
            var dialogResult = await dialogRef.Result;

            await RefreshBookList(dialogResult);
        }

        protected async Task ShowEditDialog()
        {
            var options = new DialogOptions
            {
				Position = DialogPosition.Center,
				MaxWidth = MaxWidth.Medium,
				FullWidth = true,
				DisableBackdropClick = true,
                CloseButton = true
            };

            var parameters = new DialogParameters()
            {
                { "BookId", SelectedBooks.Count() is 1 ? SelectedBooks.First().Id : null }
            };

            var dialogRef = await DialogService.ShowAsync<EditFormDialog>("Edit book", parameters, options);
        }

        protected async Task ShowDeleteDialog()
        {
            var options = new DialogOptions
            {
                DisableBackdropClick = true,
                CloseButton = true
            };

            var parameters = new DialogParameters
            {
                { "Text", $"Are you sure you want to delete {SelectedBooks.Count()} books?" },
                { "BooksToDelete", SelectedBooks }
            };

            var dialogRef = await DialogService.ShowAsync<DeleteConfirmationDialog>("Delete books", parameters, options);
            var dialogResult = await dialogRef.Result;

            await RefreshBookList(dialogResult);
        }

        private async Task RefreshBookList(DialogResult dialogResult)
        {
            if (dialogResult.Data is true && 
                dialogResult.Canceled is false)
            {
                BookList = await HttpService.GetListAsync(Endpoints.Books);
            }
        }
    }
}