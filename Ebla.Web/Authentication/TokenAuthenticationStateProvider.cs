namespace Ebla.Web.Authentication
{
    public class TokenAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public TokenAuthenticationStateProvider(ILocalStorageService localStorage, HttpClient httpClient)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            string token = await _localStorage.GetItemAsStringAsync("token");

            if (!string.IsNullOrEmpty(token))
            {
                identity = ParseTokenToClaimsIdentity(token);
                _httpClient.SetAuthorizationHeader("Bearer", token);
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        private ClaimsIdentity ParseTokenToClaimsIdentity(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

            string authenticationType = "jwt";
            var claims = jwtSecurityToken.Claims.ToList();

            return new ClaimsIdentity(claims, authenticationType);
        }
    }
}
