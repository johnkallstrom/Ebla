namespace Ebla.Web.Features.Books.Components
{
    public partial class CreateBookDialog
    {
        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        public CreateBookViewModel Model { get; set; } = new CreateBookViewModel();

        private void Cancel() => MudDialog.Cancel();

        private void Submit()
        {
            MudDialog.Close(DialogResult.Ok(0));
        }

        protected override void OnInitialized()
        {
            var options = new DialogOptions
            {
                Position = DialogPosition.TopCenter,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true,
                CloseOnEscapeKey = true,
                DisableBackdropClick = true,
            };

            MudDialog.SetTitle("New book");
            MudDialog.SetOptions(options);
        }
    }
}
