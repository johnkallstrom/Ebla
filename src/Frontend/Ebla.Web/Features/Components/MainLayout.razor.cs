namespace Ebla.Web.Features.Components
{
    public partial class MainLayout
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        bool enableDrawer = true;
        string avatarLetter = "A";

        void ToggleDrawer()
        {
            enableDrawer = !enableDrawer;
        }

        async Task SignOut()
        {
            await LocalStorage.RemoveItemAsync("token");
            NavigationManager.NavigateToAndRefresh(NavigationManager.BaseUri);
        }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            avatarLetter = user.GetAvatarLetter();
        }
    }
}
