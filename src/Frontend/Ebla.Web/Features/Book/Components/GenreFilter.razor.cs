namespace Ebla.Web.Features.Book.Components
{
    public partial class GenreFilter
    {
        [Inject]
        public IHttpService HttpService { get; set; }

        public List<GenreViewModel> Genres { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpService.GetAsync(Endpoints.Genres);

            if (response.IsSuccessStatusCode)
            {
                Genres = await response.Content.ReadFromJsonAsync<List<GenreViewModel>>();
            }
        }
    }
}
