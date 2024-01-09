namespace Ebla.Web.Features.Books.Components
{
    public partial class CreateBookDialog
    {
        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        public IEnumerable<string> Authors { get; set; } = new string[]
        {
            "Author One",
            "Author Two",
            "Author Three",
            "Author Four",
            "Author Five"
        };

        public IEnumerable<string> Genres { get; set; } = new string[]
        {
            "Genre One",
            "Genre Two",
            "Genre Three",
            "Genre Four",
            "Genre Five"
        };

        public IEnumerable<string> Libraries { get; set; } = new string[]
        {
            "Library One",
            "Library Two",
            "Library Three",
            "Library Four",
            "Library Five"
        };

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
