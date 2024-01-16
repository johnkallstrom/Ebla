namespace Ebla.Web.Services
{
    public class GenreHttpService : IGenreHttpService
    {
        private readonly HttpClient _httpClient;

        public GenreHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<GenreViewModel>> GetAllAsync()
        {
            var genres = await _httpClient.GetFromJsonAsync<IEnumerable<GenreViewModel>>(Endpoints.Genres);

            return genres;
        }
    }
}
