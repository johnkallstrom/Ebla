namespace Ebla.Web.Features.Books.Components
{
    public partial class EditFormDialog
    {
        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        [Inject]
        public IHttpService<Response> HttpService { get; set; }

        public EditBookViewModel Model { get; set; } = new EditBookViewModel();

        private async Task Submit()
        {
            throw new NotImplementedException();
        }
    }
}
