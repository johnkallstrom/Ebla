namespace Ebla.Web.Features.Books.Components
{
    public partial class CreateBookDialog
    {
        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        [Inject]
        public IAuthorHttpService AuthorHttpService { get; set; }

        [Inject]
        public IGenreHttpService GenreHttpService { get; set; }

        [Inject]
        public ILibraryHttpService LibraryHttpService { get; set; }

        public DialogOptions DialogOptions { get; set; } = new DialogOptions
        {
            Position = DialogPosition.Center,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            CloseOnEscapeKey = true,
            DisableBackdropClick = true,
        };

        public CreateBookViewModel Model { get; set; } = new CreateBookViewModel();
        public IEnumerable<AuthorViewModel> Authors { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; }
        public IEnumerable<LibraryViewModel> Libraries { get; set; }

        protected override async Task OnInitializedAsync()
        {
            MudDialog.SetTitle("New book");
            MudDialog.SetOptions(DialogOptions);
            
            Authors = await AuthorHttpService.GetAllAsync();
            Genres = await GenreHttpService.GetAllAsync();
            Libraries = await LibraryHttpService.GetAllAsync();
        }

        private void Cancel() => MudDialog.Cancel();

        private void Submit()
        {
            MudDialog.Close(DialogResult.Ok(0));
        }
    }
}
