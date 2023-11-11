namespace Ebla.Web.Extensions
{
    public static class NavigationManagerExtensions
    {
        public static void ReloadStartPage(this NavigationManager navigationManager)
        {
            navigationManager.NavigateTo(navigationManager.BaseUri, true);
        }

        public static void ReloadPage(this NavigationManager navigationManager, string uri)
        {
            navigationManager.NavigateTo(uri, true);
        }
    }
}
