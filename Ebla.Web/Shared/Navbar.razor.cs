namespace Ebla.Web.Shared
{
    public partial class Navbar
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task SignOut()
        {
            await LocalStorage.RemoveItemAsync("token");
            NavigationManager.NavigateToStartPageAndRefresh();
        }
    }
}
