namespace Ebla.Web.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        private readonly string _tokenKey;
        private readonly string _userKey;

        public CurrentUser User { get; set; }

        public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorage, NavigationManager navigationManager, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
            _configuration = configuration;

            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("Ebla.Api:BaseUrl"));
            _tokenKey = _configuration.GetValue<string>("LocalStorage:Token:Key");
            _userKey = _configuration.GetValue<string>("LocalStorage:User:Key");
        }

        public async Task InitializeAsync()
        {
            User = await _localStorage.GetItemAsync<CurrentUser>(_userKey);
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var loginResponse = new LoginResponse();

            try
            {
                var httpResponse = await _httpClient.PostAsJsonAsync($"/api/users/login", new { Username = username, Password = password });
                loginResponse = await httpResponse.Content.ReadFromJsonAsync<LoginResponse>();

                if (loginResponse.Succeeded)
                {
                    await _localStorage.SetItemAsStringAsync(_tokenKey, loginResponse.Token);

                    var currentUser = new CurrentUser
                    {
                        Username = loginResponse.User.Username,
                        Email = loginResponse.User.Email,
                        Roles = loginResponse.User.Roles.ToList(),
                        Token = loginResponse.Token,
                        IsAuthenticated = true
                    };

                    await _localStorage.SetItemAsync(_userKey, currentUser);

                    _navigationManager.ReloadStartPage();
                }
            }
            catch (Exception ex)
            {
                loginResponse.Errors = new string[] { ex.Message };
            }

            return loginResponse;
        }

        public async Task SignOutAsync()
        {
            User = null;

            await _localStorage.RemoveItemAsync(_userKey);
            await _localStorage.RemoveItemAsync(_tokenKey);
            _navigationManager.ReloadStartPage();
        }
    }
}
