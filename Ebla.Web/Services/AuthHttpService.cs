namespace Ebla.Web.Services
{
    public class AuthHttpService : IAuthHttpService
    {
        private readonly ILocalStorageService LocalStorage;
        private readonly HttpClient _httpClient;

        public AuthHttpService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            LocalStorage = localStorage;
        }

        public async Task<ResultViewModel<string>> LoginUserAsync(string username, string password)
        {
            var result = new ResultViewModel<string>();

            try
            {
                var response = await _httpClient.PostAsJsonAsync($"/api/users/login", new { Username = username, Password = password });
                result = await response.Content.ReadFromJsonAsync<ResultViewModel<string>>();

                if (result.Succeeded)
                {
                    await LocalStorage.SetItemAsStringAsync("token", result.Data);
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
