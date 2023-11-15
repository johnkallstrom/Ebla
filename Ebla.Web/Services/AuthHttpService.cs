namespace Ebla.Web.Services
{
    public class AuthHttpService : IAuthHttpService
    {
        private readonly HttpClient _httpClient;

        public AuthHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultViewModel<string>> LoginUserAsync(string username, string password)
        {
            var result = new ResultViewModel<string>();

            try
            {
                var response = await _httpClient.PostAsJsonAsync($"/api/users/login", new { Username = username, Password = password });
                result = await response.Content.ReadFromJsonAsync<ResultViewModel<string>>();
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }
    }
}
