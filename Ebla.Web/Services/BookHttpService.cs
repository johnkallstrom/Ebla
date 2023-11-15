namespace Ebla.Web.Services
{
    public class BookHttpService : IBookHttpService
    {
        private readonly IConfiguration _configuration;
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        public BookHttpService(HttpClient httpClient, ILocalStorageService localStorage, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _configuration = configuration;
        }

        public async Task<ResultViewModel<List<BookViewModel>>> GetAllAsync()
        {
            var result = new ResultViewModel<List<BookViewModel>>();

            string token = await _localStorage.GetItemAsStringAsync(_configuration.GetValue<string>("LocalStorage:Token:Key"));
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            
            try
            {
                var response = await _httpClient.GetAsync("/api/books");
                if (response.IsSuccessStatusCode)
                {
                    result.Succeeded = true;
                    result.Data = await response.Content.ReadFromJsonAsync<List<BookViewModel>>();
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result.Errors = new string[] { content };
                }
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }
    }
}