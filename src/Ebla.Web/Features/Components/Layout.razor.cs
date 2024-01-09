namespace Ebla.Web.Features.Components
{
    public partial class Layout
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        public bool EnableDrawer { get; set; } = true;
        public string AvatarLetter { get; set; } = "A";

        void ToggleDrawer() => EnableDrawer = !EnableDrawer;

        async Task Logout()
        {
            await LocalStorage.RemoveItemAsync("token");
            NavigationManager.NavigateToAndRefresh(NavigationManager.BaseUri);
        }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

            var user = authState.User;
            if (user.Identity.IsAuthenticated)
            {
                AvatarLetter = user.GetAvatarLetter();
            }
        }
    }
}
