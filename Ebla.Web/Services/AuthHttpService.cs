namespace Ebla.Web.Services
{
    public class AuthHttpService : IAuthHttpService
    {
        private readonly IConfiguration _configuration;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        private readonly string _tokenKey;

        public AuthHttpService(HttpClient httpClient, ILocalStorageService localStorage, NavigationManager navigationManager, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
            _configuration = configuration;
            _tokenKey = _configuration.GetValue<string>("LocalStorage:Token:Key");
        }

        public async Task<bool> IsAuthenticated()
        {
            var token = await _localStorage.GetItemAsStringAsync(_tokenKey);

            return !string.IsNullOrEmpty(token) ? true : false;
        }

        public async Task<ResultViewModel<string>> LoginAsync(string username, string password)
        {
            var result = new ResultViewModel<string>();

            try
            {
                var response = await _httpClient.PostAsJsonAsync($"/api/users/login", new { Username = username, Password = password });
                result = await response.Content.ReadFromJsonAsync<ResultViewModel<string>>();

                if (result.Succeeded)
                {
                    await _localStorage.SetItemAsStringAsync(_tokenKey, result.Data);
                    _navigationManager.ReloadStartPage();
                }
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }

        public async Task SignOutAsync()
        {
            await _localStorage.RemoveItemAsync(_tokenKey);
            _navigationManager.ReloadStartPage();
        }
    }
}
