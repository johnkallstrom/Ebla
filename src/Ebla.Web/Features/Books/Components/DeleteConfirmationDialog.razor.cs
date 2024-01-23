namespace Ebla.Web.Features.Books.Components
{
    public partial class DeleteConfirmationDialog
    {
        [Inject]
        public IHttpService<Response> HttpService { get; set; }

        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public HashSet<BookViewModel> BooksToDelete { get; set; } = new HashSet<BookViewModel>();

        [Parameter]
        public string Text { get; set; }

        private async Task DeleteBooksAsync()
        {
            throw new NotImplementedException();
        }
    }
}
