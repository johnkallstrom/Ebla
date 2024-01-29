namespace Ebla.Web.Features.Books.Components
{
    public partial class DeleteConfirmationDialog
    {
        [Inject]
        public IHttpService<Response> HttpService { get; set; }

        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public int[] Ids { get; set; }

        [Parameter]
        public string Text { get; set; }

        private async Task DeleteBooksAsync()
        {
            var response = await HttpService.DeleteAsync($"{Endpoints.Books}/delete", Ids);
            if (response.Succeeded)
            {
                MudDialog.Close(DialogResult.Ok(true));
            }
        }
    }
}
