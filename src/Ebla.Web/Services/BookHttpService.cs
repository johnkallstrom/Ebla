namespace Ebla.Web.Services
{
	public class BookHttpService : IBookHttpService
	{
		private readonly HttpClient _httpClient;

		public BookHttpService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<BookViewModel>> GetAllAsync()
		{
			var books = await _httpClient.GetFromJsonAsync<IEnumerable<BookViewModel>>(Endpoints.Books);

			return books;
		}

		public async Task<BookViewModel> GetAsync(int bookId)
		{
			var book = await _httpClient.GetFromJsonAsync<BookViewModel>($"{Endpoints.Books}/{bookId}");

			return book;
		}
	}
}
