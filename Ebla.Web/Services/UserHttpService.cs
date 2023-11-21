namespace Ebla.Web.Services
{
    public class UserHttpService : IUserHttpService
    {
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        public UserHttpService(HttpClient httpClient, ILocalStorageService localStorage, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
        }

        public async Task<List<UserViewModel>> GetAllAsync()
        {
            var users = await _httpClient.GetFromJsonAsync<List<UserViewModel>>("/api/users");

            return users;
        }

        public async Task<ResultViewModel<string>> LoginAsync(string username, string password)
        {
            var result = new ResultViewModel<string>();

            try
            {
                var httpResponse = await _httpClient.PostAsJsonAsync($"/api/users/login", new { Username = username, Password = password });
                result = await httpResponse.Content.ReadFromJsonAsync<ResultViewModel<string>>();

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