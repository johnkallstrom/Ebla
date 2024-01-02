namespace Ebla.Web.Features.Shared
{
    public partial class NavigationMenu
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        public string FullName { get; set; } = "Firstname Lastname";
        public string Role { get; set; } = "Role";

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

            var user = authState.User;
            if (user.Identity.IsAuthenticated)
            {
                FullName = user.GetFullName();
                Role = user.GetPrimaryRole();
            }
        }
    }
}