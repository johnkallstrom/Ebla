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

            if (!string.IsNullOrEmpty(token) && !HasTokenExpired(token))
            {
                identity = ParseTokenToClaimsIdentity(token);
                _httpClient.SetAuthorizationHeader("Bearer", token);
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        private bool HasTokenExpired(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

            var expires = jwtSecurityToken.ValidTo;
            var now = DateTime.UtcNow;

            return expires < now;
        }

        private ClaimsIdentity ParseTokenToClaimsIdentity(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

            var claims = jwtSecurityToken.Claims.ToList();

            var identity = new ClaimsIdentity(
                claims: claims, 
                authenticationType: "jwt", 
                nameType: "name", 
                roleType: "role");

            return identity;
        }
    }
}
