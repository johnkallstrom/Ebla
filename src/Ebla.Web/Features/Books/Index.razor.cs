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

        protected async Task ShowCreateBookDialogAsync()
        {
            var dialogRef = await DialogService.ShowAsync<CreateBookDialog>("New book");

            var dialogResult = await dialogRef.Result;
            if (dialogResult.Data is true && dialogResult.Canceled is false)
            {
                BookList = await HttpService.GetListAsync(Endpoints.Books);
            }
        }
    }
}