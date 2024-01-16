namespace Ebla.Web.Services
{
    public class AuthorHttpService : IAuthorHttpService
    {
        private readonly HttpClient _httpClient;

        public AuthorHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AuthorViewModel>> GetAllAsync()
        {
            var authors = await _httpClient.GetFromJsonAsync<IEnumerable<AuthorViewModel>>(Endpoints.Authors);

            return authors;
        }
    }
}
