﻿namespace Ebla.Web.Features.Books.Components
{
    public partial class DeleteConfirmationDialog
    {
        [Inject]
        public IHttpService<Response> HttpService { get; set; }

        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public HashSet<BookViewModel> BooksToDelete { get; set; }

        [Parameter]
        public string Text { get; set; }

        private async Task DeleteBooksAsync()
        {
            var model = new DeleteBooksViewModel
            {
                Ids = BooksToDelete?.Select(x => x.Id).ToArray()
            };

            var response = await HttpService.DeleteAsync($"{Endpoints.Books}/delete", model);
            if (response.Succeeded)
            {
                MudDialog.Close(DialogResult.Ok(true));
            }
        }
    }
}
