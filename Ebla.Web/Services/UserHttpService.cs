namespace Ebla.Web.Services
{
    public class UserHttpService : IUserHttpService
    {
        private readonly HttpClient _httpClient;

        public UserHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task LoginUserAsync(string username, string password)
        {
            Console.WriteLine($"{username}, {password}");
            Console.WriteLine(_httpClient.BaseAddress.ToString());

            throw new NotImplementedException();
        }
    }
}
