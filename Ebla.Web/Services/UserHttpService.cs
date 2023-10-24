using System.Text.Json;

namespace Ebla.Web.Services
{
    public class UserHttpService : IUserHttpService
    {
        private readonly HttpClient _httpClient;

        public UserHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<object> LoginUserAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/users/login", new { Username = username, Password = password });

            throw new NotImplementedException();
        }
    }
}
