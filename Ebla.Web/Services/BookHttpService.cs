namespace Ebla.Web.Services
{
    public class BookHttpService : IBookHttpService
    {
        private readonly HttpClient _httpClient;

        public BookHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BookViewModel>> GetAllAsync()
        {
            var books = Enumerable.Empty<BookViewModel>();

            var response = await _httpClient.GetAsync("/api/books");

            if (response.IsSuccessStatusCode)
            {
                books = await response.Content.ReadFromJsonAsync<IEnumerable<BookViewModel>>();
            }

            return books.ToList();
        }
    }
}