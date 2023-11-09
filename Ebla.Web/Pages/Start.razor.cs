namespace Ebla.Web.Pages
{
    public partial class Start
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

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
    }
}
