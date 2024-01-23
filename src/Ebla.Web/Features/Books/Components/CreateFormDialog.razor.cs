namespace Ebla.Web.Features.Books.Components
{
	public partial class CreateFormDialog
    {
        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IHttpService<Response<int>> HttpService { get; set; }

        [Inject]
        public IAuthorHttpService AuthorHttpService { get; set; }

        [Inject]
        public IGenreHttpService GenreHttpService { get; set; }

        [Inject]
        public ILibraryHttpService LibraryHttpService { get; set; }

        public CreateBookViewModel Model { get; set; } = new CreateBookViewModel();

        [Label("Author")]
        [Required(ErrorMessage = "Please select an author")]
        [DataType(DataType.Text)]
        public string SelectedAuthor { get; set; }
        public IEnumerable<AuthorViewModel> Authors { get; set; } = new List<AuthorViewModel>();

		[Label("Genre")]
		[Required(ErrorMessage = "Please select a genre")]
		[DataType(DataType.Text)]
		public string SelectedGenre { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();

		[Required(ErrorMessage = "Please select atleast one library")]
		[DataType(DataType.Text)]
		public IEnumerable<string> SelectedLibraries { get; set; } = new List<string>();
        public IEnumerable<LibraryViewModel> Libraries { get; set; } = new List<LibraryViewModel>();

        protected override async Task OnInitializedAsync()
        {
            Authors = await AuthorHttpService.GetAllAsync();
            Genres = await GenreHttpService.GetAllAsync();
            Libraries = await LibraryHttpService.GetAllAsync();
        }

        private async Task Submit()
        {
            GetIdsFromSelectedNames();

            var response = await HttpService.PostAsync($"{Endpoints.Books}/create", Model);
            if (response.Succeeded)
            {
                MudDialog.Close(DialogResult.Ok(true));
                Snackbar.Add("New book added", Severity.Success);
            }
            else
            {
                Snackbar.Add("Something went wrong", Severity.Error);
            }
        }

        private void GetIdsFromSelectedNames()
        {
            if (!string.IsNullOrEmpty(SelectedAuthor) && Authors is not null)
            {
                Model.AuthorId = Authors.FirstOrDefault(a => a.Name.Equals(SelectedAuthor)).Id;
            }
            if (!string.IsNullOrEmpty(SelectedGenre) && Genres is not null)
            {
                Model.GenreId = Genres.FirstOrDefault(g => g.Name.Equals(SelectedGenre)).Id;
            }
            if (SelectedLibraries is not null && SelectedLibraries.Count() > 0 && Libraries is not null)
            {
                Model.LibraryIds = Libraries.Where(l => SelectedLibraries.Contains(l.Name)).Select(l => l.Id).ToArray();
            }
        }
    }
}
