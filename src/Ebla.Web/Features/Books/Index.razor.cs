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
            BookList = await HttpService.GetListAsync($"{Endpoints.Books}");
        }

        protected void OpenAddDialog()
        {
            var options = new DialogOptions
            {
                FullWidth = true,
                CloseOnEscapeKey = true,
                DisableBackdropClick = true,
                MaxWidth = MaxWidth.Medium,
                Position = DialogPosition.TopCenter,
            };

            DialogService.Show<AddBookDialog>("Lorem ipsum", options);
        }
    }
}