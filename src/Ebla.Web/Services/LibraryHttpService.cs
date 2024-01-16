namespace Ebla.Web.Services
{
    public class LibraryHttpService : ILibraryHttpService
    {
        private readonly HttpClient _httpClient;

        public LibraryHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<LibraryViewModel>> GetAllAsync()
        {
            var libraries = await _httpClient.GetFromJsonAsync<IEnumerable<LibraryViewModel>>(Endpoints.Libraries);

            return libraries;
        }
    }
}
