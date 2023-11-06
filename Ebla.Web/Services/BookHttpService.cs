namespace Ebla.Web.Services
{
    public class BookHttpService : IBookHttpService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        public BookHttpService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<List<BookViewModel>> GetAllAsync()
        {
            var books = Enumerable.Empty<BookViewModel>();

            string token = await _localStorage.GetItemAsStringAsync("token");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await _httpClient.GetAsync("/api/books");
            if (response.IsSuccessStatusCode)
            {
                books = await response.Content.ReadFromJsonAsync<IEnumerable<BookViewModel>>();
            }

            return books.ToList();
        }
    }
}