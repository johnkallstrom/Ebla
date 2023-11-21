namespace Ebla.Web.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        public CurrentUser User { get; set; }

        public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorage, NavigationManager navigationManager, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
            _configuration = configuration;

            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("Ebla.Api:BaseUrl"));
        }

        public async Task InitializeAsync()
        {
            User = await _localStorage.GetItemAsync<CurrentUser>("user");
        }

        public async Task<LoginResultViewModel> LoginAsync(string username, string password)
        {
            var result = new LoginResultViewModel();

            try
            {
                var httpResponse = await _httpClient.PostAsJsonAsync($"/api/users/login", new { Username = username, Password = password });
                result = await httpResponse.Content.ReadFromJsonAsync<LoginResultViewModel>();

                if (result.Succeeded)
                {
                    var currentUser = new CurrentUser
                    {
                        Username = result.User.Username,
                        Email = result.User.Email,
                        Roles = result.User.Roles.ToList(),
                        Token = result.Token,
                        IsAuthenticated = true
                    };

                    await _localStorage.SetItemAsync("user", currentUser);

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
            User = null;

            await _localStorage.RemoveItemAsync("user");
            _navigationManager.ReloadStartPage();
        }
    }
}
