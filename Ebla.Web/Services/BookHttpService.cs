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
            var books = await _httpClient.GetFromJsonAsync<IEnumerable<BookViewModel>>("/api/books");

            return books.ToList();
        }
    }
}
