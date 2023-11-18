namespace Ebla.Web.Authentication
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> LoginAsync(string username, string password);
        Task SignOutAsync();
        Task InitializeAsync();
        public CurrentUser User { get; set; }
    }
}