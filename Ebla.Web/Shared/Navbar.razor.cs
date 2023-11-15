namespace Ebla.Web.Shared
{
    public partial class Navbar
    {
        [Inject]
        public IAuthHttpService AuthHttpService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task SignOut()
        {
            await AuthHttpService.SignOutAsync();
            NavigationManager.ReloadStartPage();
        }
    }
}
