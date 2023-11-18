namespace Ebla.Web.Shared
{
    public partial class Navbar
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        public async Task SignOut()
        {
            await AuthenticationService.SignOutAsync();
        }
    }
}
