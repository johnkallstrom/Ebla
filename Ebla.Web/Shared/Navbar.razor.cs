namespace Ebla.Web.Shared
{
    public partial class Navbar
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public bool IsAuthorized { get; set; }

        protected override async Task OnInitializedAsync()
        {
            string token = await LocalStorage.GetItemAsStringAsync("token");
            if (!string.IsNullOrEmpty(token))
            {
                IsAuthorized = true;
            }

            // Todo: also check if token has expired
        }

        public async Task SignOut()
        {
            await LocalStorage.RemoveItemAsync("token");
            NavigationManager.NavigateTo(NavigationManager.BaseUri, true);
        }
    }
}
