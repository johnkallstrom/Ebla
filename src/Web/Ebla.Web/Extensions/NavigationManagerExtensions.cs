namespace Ebla.Web.Extensions
{
    public static class NavigationManagerExtensions
    {
        public static void NavigateToAndRefresh(this NavigationManager navigationManager, string uri)
        {
            navigationManager.NavigateTo(uri, true);
        }
    }
}