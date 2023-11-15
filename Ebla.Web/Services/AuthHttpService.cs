namespace Ebla.Web.Services
{
    public class AuthHttpService : IAuthHttpService
    {
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        public AuthHttpService(HttpClient httpClient, ILocalStorageService localStorage, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
        }

        public async Task<bool> IsAuthenticated()
        {
            var token = await _localStorage.GetItemAsStringAsync("token");

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
                    await _localStorage.SetItemAsStringAsync("token", result.Data);
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
            await _localStorage.RemoveItemAsync("token");
            _navigationManager.ReloadStartPage();
        }
    }
}
