namespace Ebla.Web.Services
{
    public class UserHttpService : IUserHttpService
    {
        private readonly HttpClient _httpClient;

        public UserHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserViewModel>> GetAllAsync()
        {
            var users = await _httpClient.GetFromJsonAsync<List<UserViewModel>>("/api/users");

            return users;
        }
    }
}